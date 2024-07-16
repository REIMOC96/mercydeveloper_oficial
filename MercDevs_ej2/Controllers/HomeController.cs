using MercDevs_ej2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MercDevs_ej2.ViewModel;

namespace MercDevs_ej2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MercydevsEjercicio2Context _context;

        public HomeController(ILogger<HomeController> logger, MercydevsEjercicio2Context context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var equipos = await _context.Recepcionequipos
                                        .Where(e => e.Estado != 0)
                                        .Include(e => e.IdClienteNavigation)
                                        .Include(e => e.IdServicioNavigation)
                                        .Select(e => new EquipoClienteViewModel
                                        {
                                            Equipo = e,
                                            ClienteNombre = e.IdClienteNavigation.Nombre,
                                            ServicioNombre = e.IdServicioNavigation.Nombre
                                        })
                                        .ToListAsync();

            return View(equipos);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // función de Logout
        public async Task<IActionResult> Salir()
        {
            // Eliminar la cookie de autenticación
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirigir al usuario a la página de inicio de sesión u otra página
            return RedirectToAction("Login", "Loggeo");
        }
    }
}
