using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservarCanchas_ProyectoProgramacionIV.Models;

namespace ReservarCanchas_ProyectoProgramacionIV.Controllers
{
    public class CalendariosController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CalendariosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: Calendarios
        public async Task<IActionResult> Index()
        {
            var baseDatos_ReservarCanchas_ProyectoProgramacionIV = _context.Calendario.Include(c => c.Cancha);
            return View(await baseDatos_ReservarCanchas_ProyectoProgramacionIV.ToListAsync());
        }

        // GET: Calendarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendario
                .Include(c => c.Cancha)
                .FirstOrDefaultAsync(m => m.CalendarioId == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // GET: Calendarios/Create
        public IActionResult Create()
        {
            ViewData["CanchaId"] = new SelectList(_context.Set<Cancha>(), "CanchaId", "CanchaId");
            return View();
        }

        // POST: Calendarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalendarioId,FechaInicio,FechaFin,Estado,NotasDetallada,CanchaId")] Calendario calendario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanchaId"] = new SelectList(_context.Set<Cancha>(), "CanchaId", "CanchaId", calendario.CanchaId);
            return View(calendario);
        }

        // GET: Calendarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendario.FindAsync(id);
            if (calendario == null)
            {
                return NotFound();
            }
            ViewData["CanchaId"] = new SelectList(_context.Set<Cancha>(), "CanchaId", "CanchaId", calendario.CanchaId);
            return View(calendario);
        }

        // POST: Calendarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalendarioId,FechaInicio,FechaFin,Estado,NotasDetallada,CanchaId")] Calendario calendario)
        {
            if (id != calendario.CalendarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarioExists(calendario.CalendarioId))
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
            ViewData["CanchaId"] = new SelectList(_context.Set<Cancha>(), "CanchaId", "CanchaId", calendario.CanchaId);
            return View(calendario);
        }

        // GET: Calendarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendario = await _context.Calendario
                .Include(c => c.Cancha)
                .FirstOrDefaultAsync(m => m.CalendarioId == id);
            if (calendario == null)
            {
                return NotFound();
            }

            return View(calendario);
        }

        // POST: Calendarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calendario = await _context.Calendario.FindAsync(id);
            if (calendario != null)
            {
                _context.Calendario.Remove(calendario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioExists(int id)
        {
            return _context.Calendario.Any(e => e.CalendarioId == id);
        }
    }
}
