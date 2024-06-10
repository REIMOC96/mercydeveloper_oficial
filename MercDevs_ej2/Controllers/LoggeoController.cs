using Microsoft.AspNetCore.Mvc;
using MercDevs_ej2.Models;
using MercDevs_ej2.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MercDevs_ej2.Controllers
{
    public class LoggeoController : Controller
    {
        private readonly MercydevsEjercicio2Context _context;

        public LoggeoController(MercydevsEjercicio2Context context) => _context = context;

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(UsuarioVM usuariovm)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Nombre == usuariovm.Nombre && u.Apellido == usuariovm.Apellido))
            {
                ModelState.AddModelError("Nombre", "Ya existe un usuario con este nombre y apellido");
            }

            if (!ModelState.IsValid)
            {
                return View(usuariovm);
            }

            if (usuariovm.Password != usuariovm.ConfPassword)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View(usuariovm);
            }

            // Crear un nuevo usuario
            Usuario usuario = new Usuario()
            {
                Nombre = usuariovm.Nombre,
                Apellido = usuariovm.Apellido,
                Correo = usuariovm.Correo,
                Password = HashPassword(usuariovm.Password) // Guardar la contraseña hasheada
            };

            // control de errores:
            Console.WriteLine($"Registro - Hash de la contraseña: {usuario.Password}");

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            // Verify saved user
            var savedUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == usuario.IdUsuario);
            if (savedUser != null)
            {
                Console.WriteLine($"Usuario guardado - ID: {savedUser.IdUsuario}, Correo: {savedUser.Correo}, Hash: {savedUser.Password}");
            }

            if (usuario.IdUsuario != 0)
            {
                return RedirectToAction("Login", "Loggeo");
            }

            ViewData["Mensaje"] = "No se pudo crear el Usuario";
            return View(usuariovm);
        }

        // Método para calcular el hash de la contraseña, esto es bastante interesante 
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Generar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir el hash a una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            Response.Headers["Cache-control"] = "no-Cache, no-Store, must-revalidate";
            Response.Headers["Pragma"] = "no-Cache";
            Response.Headers["Expires"] = "0";
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View(); // Asegúrate de devolver una vista en caso de que el usuario no esté autenticado
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Mensaje"] = "Datos no válidos.";
                return View(loginvm);
            }

            // Hashear la contraseña ingresada para compararla
            string hashedPassword = HashPassword(loginvm.Password);

            // use esto para debugear, muestra cosas en consola para poder comparar el hashing con el de mi bbdd
            Console.WriteLine($"Login - Hash de la contraseña ingresada: {hashedPassword}");

            // Buscar el usuario con el correo y la contraseña hasheada
            Usuario? usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == loginvm.Correo && u.Password == hashedPassword);

            // esto de aqui lo hice solo para debugear, tenia un drama para usar el hashing, resulta que el problema
            //era mi bbdd, el hashing genera un valor hexadecimal de una longitud de 64 caracateres, por lo que 
            //requeri de actualizar mi bbdd en la password, para que pudiera guardar esa cantidad de caracteres
            //entonces, al buscar usuario para el login, encontraba una PSW encriptada de 45chars, y la comparaba con la 
            //completa que tenia hasheada ingresada por el usuario para logearse
            if (usuario != null)
            {
                Console.WriteLine($"Login - Usuario encontrado: {usuario.Correo} - Hash almacenado: {usuario.Password}");
            }
            else
            {
                Console.WriteLine("Login - No se encontró ningún usuario con las credenciales proporcionadas");
            }

            if (usuario == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias de credenciales";
                return View(loginvm);
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };
            ClaimsIdentity claim = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties propiedades = new AuthenticationProperties() { 
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claim),
                propiedades
                );


            // redirigirlo a la página principal
            return RedirectToAction("Index", "Home");
        }
    }
}
