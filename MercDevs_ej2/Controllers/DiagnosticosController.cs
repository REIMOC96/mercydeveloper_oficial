using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercDevs_ej2.Models;

namespace MercDevs_ej2.Controllers
{
    public class DiagnosticosController : Controller
    {
        private readonly MercydevsEjercicio2Context _context;

        public DiagnosticosController(MercydevsEjercicio2Context context)
        {
            _context = context;
        }

        // GET: Diagnosticos
        public async Task<IActionResult> Index()
        {
            var mercydevsEjercicio2Context = _context.Diagnosticosolucions.Include(d => d.IdFichaTecnicaNavigation);
            return View(await mercydevsEjercicio2Context.ToListAsync());
        }

        // GET: Diagnosticos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosticosolucion = await _context.Diagnosticosolucions
                .Include(d => d.IdFichaTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdDiagnosticoSolucion == id);
            if (diagnosticosolucion == null)
            {
                return NotFound();
            }

            return View(diagnosticosolucion);
        }

        // GET: Diagnosticos/Create
        public IActionResult Create()
        {
            ViewData["IdFichaTecnica"] = new SelectList(_context.Datosfichatecnicas, "IdFichaTecnica", "IdFichaTecnica");
            return View();
        }

        // POST: Diagnosticos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDiagnosticoSolucion,DescripcionDiagnostico,DescripcionSolucion,IdFichaTecnica")] Diagnosticosolucion diagnosticosolucion)
        {
            if(diagnosticosolucion.DescripcionSolucion != null && diagnosticosolucion.DescripcionDiagnostico !=null)
            {
                _context.Add(diagnosticosolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFichaTecnica"] = new SelectList(_context.Datosfichatecnicas, "IdFichaTecnica", "IdFichaTecnica", diagnosticosolucion.IdFichaTecnica);
            return View(diagnosticosolucion);
        }

        // GET: Diagnosticos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {


            var diagnosticosolucion = await _context.Diagnosticosolucions.FindAsync(id);
            if (diagnosticosolucion == null)
            {
                return NotFound();
            }
            ViewData["IdFichaTecnica"] = new SelectList(_context.Datosfichatecnicas, "IdFichaTecnica", "IdFichaTecnica", diagnosticosolucion.IdFichaTecnica);
            return View(diagnosticosolucion);
        }

        // POST: Diagnosticos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDiagnosticoSolucion,DescripcionDiagnostico,DescripcionSolucion,IdFichaTecnica")] Diagnosticosolucion diagnosticosolucion)
        {
            if (id != diagnosticosolucion.IdDiagnosticoSolucion)
            {
                return NotFound();
            }

            if (diagnosticosolucion.IdDiagnosticoSolucion == id)
            {
                try
                {
                    _context.Update(diagnosticosolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiagnosticosolucionExists(diagnosticosolucion.IdDiagnosticoSolucion))
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
            ViewData["IdFichaTecnica"] = new SelectList(_context.Datosfichatecnicas, "IdFichaTecnica", "IdFichaTecnica", diagnosticosolucion.IdFichaTecnica);
            return View(diagnosticosolucion);
        }


        // GET: Diagnosticos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diagnosticosolucion = await _context.Diagnosticosolucions
                .Include(d => d.IdFichaTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdDiagnosticoSolucion == id);
            if (diagnosticosolucion == null)
            {
                return NotFound();
            }

            return View(diagnosticosolucion);
        }

        // POST: Diagnosticos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diagnosticosolucion = await _context.Diagnosticosolucions.FindAsync(id);
            if (diagnosticosolucion != null)
            {
                _context.Diagnosticosolucions.Remove(diagnosticosolucion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiagnosticosolucionExists(int id)
        {
            return _context.Diagnosticosolucions.Any(e => e.IdDiagnosticoSolucion == id);
        }
    }
}
