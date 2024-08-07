﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercDevs_ej2.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MercDevs_ej2.Controllers
{
    [Authorize]
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
            var recepcionesEquipos = await _context.Recepcionequipos
                .Include(r => r.IdClienteNavigation)
                .Include(r => r.IdServicioNavigation)
                .ToListAsync();

            return View(recepcionesEquipos);
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
        [HttpPost]       public async Task<IActionResult> Create([Bind("Id,IdCliente,IdServicio,Fecha,TipoPc,Accesorio,MarcaPc,ModeloPc,Nserie,CapacidadRam,TipoAlmacenamiento,CapacidadAlmacenamiento,TipoGpu,Grafico, Estado")] Recepcionequipo recepcionequipo)
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
        { nameof(recepcionequipo.Grafico), recepcionequipo.Grafico },
        {nameof(recepcionequipo.Estado), recepcionequipo.Estado },
    };

            // Verificar si alguna de las propiedades es nula o en el caso de int, si es igual a 0
            //quiero ver tambien si puedo validar una fecha, eso sera interesante :}
            //o quiza lo mejor sea agregar la fecha desde el sistema del pc, seria lo mas acertado 
            foreach (var dato in tablaDato)
            {
                if (dato.Value == null)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdCliente,IdServicio,Fecha,TipoPc,Accesorio,MarcaPc,ModeloPc,Nserie,CapacidadRam,TipoAlmacenamiento,CapacidadAlmacenamiento,TipoGpu,Grafico,Estado")] Recepcionequipo recepcionequipo)
        {
            if (id != recepcionequipo.Id)
            {
                return NotFound();
            }
             
            if (id == recepcionequipo.Id)
            {
                try
                {
                    _context.Update(recepcionequipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionequipoExists(recepcionequipo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", recepcionequipo.IdCliente);
            ViewData["IdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", recepcionequipo.IdServicio);
            return View(recepcionequipo);
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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //funcion buscar recepcion por cliente 
        public async Task<IActionResult>RepCliente(int id)
           
        {
             var equipos = await _context.Recepcionequipos
                                        .Where(e => e.IdCliente  == id)
                                        .Include(e => e.IdClienteNavigation)
                                        .Include(e => e.IdServicioNavigation)
                                        .ToListAsync();
            return View(equipos);
        }

        // GET: Recepcionequipoes/completado/

        // funcion para actualizar el estado, lo haremos en dos partes, una confirmacion y una ejecucion

        //esta redirecciona a una confirmacion de lo que se va a ejecutar
        public async Task<IActionResult> Completado(int id) {

            {
                if (id == 0)
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



        }
        
        // esta es la funcion de actualizar el valor ya una vez confirmado
        // GET: Recepcionequipoes/Confirmado/5
        public async Task<IActionResult> Confirmado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var recepcionequipo = await _context.Recepcionequipos.FindAsync(id);
            if (recepcionequipo == null)
            {
                return NotFound();
            }

            recepcionequipo.Estado = 0;

            try
            {
                _context.Recepcionequipos.Update(recepcionequipo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecepcionequipoExists(recepcionequipo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Index","Home");
        }


        //se recomienda manentener esta funcion al final
        private bool RecepcionequipoExists(int id)
        {
            return _context.Recepcionequipos.Any(e => e.Id == id);

        }


    }   
}
