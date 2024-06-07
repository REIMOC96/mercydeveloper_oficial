using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercDevs_ej2.Models;
using Microsoft.CodeAnalysis;
using System;

namespace MercDevs_ej2.Controllers
{
    public class RecepcionequipoesController : Controller
    {
        private readonly MercydevsEjercicio2Context _context;

        public RecepcionequipoesController(MercydevsEjercicio2Context context)
        {
            _context = context;
        }

        // GET: Recepcionequipoes
        public async Task<IActionResult> Index()
        {
            var mercydevsEjercicio2Context = _context.Recepcionequipos.Include(r => r.IdClienteNavigation).Include(r => r.IdServicioNavigation);
            return View(await mercydevsEjercicio2Context.ToListAsync());
        }

        // GET: Recepcionequipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionequipo = await _context.Recepcionequipos
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcionequipo == null)
            {
                return NotFound();
            }

            return View(recepcionequipo);
        }

        // GET: Recepcionequipoes/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: Recepcionequipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]





        public async Task<IActionResult> Create([Bind("Id,IdCliente,IdServicio,Fecha,TipoPc,Accesorio,MarcaPc,ModeloPc,Nserie,CapacidadRam,TipoAlmacenamiento,CapacidadAlmacenamiento,TipoGpu,Grafico")] Recepcionequipo recepcionequipo)
        {
            // primero quise hacer un if para validar los dato propios de la tabla, pero era muy largo
            //le pregunte a gpt-san como podia factorizar mejor el codigo y me explico que podia hacer un diccionario y recorrerlo
            //con el foreach se hizo rapido, entendi bastante con esto, puedo hacer filtros generales con el if y 
            //aplicarlo a un monton de datos usando diccionarios y foreach, esto acomoda mucho las cosas ojito O.O

            var tablaDato = new Dictionary<string, object?>
            //llamo al nombre del valor que quiero atribuir, y luego llamo al mismo valor, asi lo asigno a mi diccionario
    {
        { nameof(recepcionequipo.MarcaPc), recepcionequipo.MarcaPc  },
        { nameof(recepcionequipo.Fecha), recepcionequipo.Fecha },
        { nameof(recepcionequipo.TipoPc), recepcionequipo.TipoPc },
        { nameof(recepcionequipo.Accesorio), recepcionequipo.Accesorio },
        { nameof(recepcionequipo.ModeloPc), recepcionequipo.ModeloPc },
        { nameof(recepcionequipo.Nserie), recepcionequipo.Nserie },
        { nameof(recepcionequipo.CapacidadRam), recepcionequipo.CapacidadRam },
        { nameof(recepcionequipo.TipoAlmacenamiento), recepcionequipo.TipoAlmacenamiento },
        { nameof(recepcionequipo.CapacidadAlmacenamiento), recepcionequipo.CapacidadAlmacenamiento },
        { nameof(recepcionequipo.TipoGpu), recepcionequipo.TipoGpu },
        { nameof(recepcionequipo.Grafico), recepcionequipo.Grafico }
    };

            // Verificar si alguna de las propiedades es nula o en el caso de int, si es igual a 0
            //quiero ver tambien si puedo validar una fecha, eso sera interesante :}
            //o quiza lo mejor sea agregar la fecha desde el sistema del pc, seria lo mas acertado 
            foreach (var dato in tablaDato)
            {
                if (dato.Value == null || (dato.Value is int intValue && intValue == 0))
                {
                    // Si cualquier valor no cumple con los requisitos, se configura ViewData y se retorna la vista
                    ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", recepcionequipo.IdCliente);
                    ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", recepcionequipo.IdServicio);
                    return View(recepcionequipo);
                }
            }

            // Si todas las propiedades cumplen con los requisitos, se guarda en la base de datos
            _context.Add(recepcionequipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        // GET: Recepcionequipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionequipo = await _context.Recepcionequipos.FindAsync(id);
            if (recepcionequipo == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", recepcionequipo.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", recepcionequipo.IdServicio);
            return View(recepcionequipo);
        }

        // POST: Recepcionequipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdServicio,Fecha,TipoPc,Accesorio,MarcaPc,ModeloPc," +
"Nserie,CapacidadRam,TipoAlmacenamiento,CapacidadAlmacenamiento,TipoGpu,Grafico")] Recepcionequipo recepcionequipo)
        {
            if (id != recepcionequipo.Id)
            {
                return NotFound();
            }

            if (recepcionequipo.IdCliente != 0) // Verificar si el modelo es válido
            {
                try
                {
                    _context.Update(recepcionequipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionequipoExists(recepcionequipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "No se pudieron guardar los cambios. El registro fue actualizado o eliminado por otro usuario.");
                    }
                }
                catch (Exception ex)
                {
                    // Imprimir el mensaje de error en la consola
                    Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");

                    // También puedes imprimir detalles adicionales si los necesitas
                    Console.WriteLine($"Detalles adicionales: {ex.InnerException}");

                    ModelState.AddModelError(string.Empty, $"Ocurrió un error: {ex.Message}");
                }
            }

            // Si el modelo no es válido o si ocurre un error, vuelve a cargar los datos necesarios para mostrar la vista de edición
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", recepcionequipo.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", recepcionequipo.IdServicio);
            return View(recepcionequipo);
        }


        private bool RecepcionequipoExists(int id)
        {
            return _context.Recepcionequipos.Any(e => e.Id == id);
        }






        // GET: Recepcionequipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recepcionequipo = await _context.Recepcionequipos
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdServicioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recepcionequipo == null)
            {
                return NotFound();
            }

            return View(recepcionequipo);
        }

        // POST: Recepcionequipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recepcionequipo = await _context.Recepcionequipos.FindAsync(id);
            if (recepcionequipo != null)
            {
                _context.Recepcionequipos.Remove(recepcionequipo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
