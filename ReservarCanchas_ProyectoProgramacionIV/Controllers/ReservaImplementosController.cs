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
    public class ReservaImplementosController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public ReservaImplementosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: ReservaImplementos
        public async Task<IActionResult> Index()
        {
            var baseDatos_ReservarCanchas_ProyectoProgramacionIV = _context.ReservaImplemento.Include(r => r.Implemento).Include(r => r.Reserva);
            return View(await baseDatos_ReservarCanchas_ProyectoProgramacionIV.ToListAsync());
        }

        // GET: ReservaImplementos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaImplemento = await _context.ReservaImplemento
                .Include(r => r.Implemento)
                .Include(r => r.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaImplemento == null)
            {
                return NotFound();
            }

            return View(reservaImplemento);
        }

        // GET: ReservaImplementos/Create
        public IActionResult Create()
        {
            ViewData["ImplementoId"] = new SelectList(_context.Set<Implemento>(), "Id", "Id");
            ViewData["ReservaId"] = new SelectList(_context.Set<Reserva>(), "ReservaId", "ReservaId");
            return View();
        }

        // POST: ReservaImplementos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CantidadSolicitada,ReservaId,ImplementoId")] ReservaImplemento reservaImplemento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaImplemento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImplementoId"] = new SelectList(_context.Set<Implemento>(), "Id", "Id", reservaImplemento.ImplementoId);
            ViewData["ReservaId"] = new SelectList(_context.Set<Reserva>(), "ReservaId", "ReservaId", reservaImplemento.ReservaId);
            return View(reservaImplemento);
        }

        // GET: ReservaImplementos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaImplemento = await _context.ReservaImplemento.FindAsync(id);
            if (reservaImplemento == null)
            {
                return NotFound();
            }
            ViewData["ImplementoId"] = new SelectList(_context.Set<Implemento>(), "Id", "Id", reservaImplemento.ImplementoId);
            ViewData["ReservaId"] = new SelectList(_context.Set<Reserva>(), "ReservaId", "ReservaId", reservaImplemento.ReservaId);
            return View(reservaImplemento);
        }

        // POST: ReservaImplementos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CantidadSolicitada,ReservaId,ImplementoId")] ReservaImplemento reservaImplemento)
        {
            if (id != reservaImplemento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaImplemento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaImplementoExists(reservaImplemento.Id))
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
            ViewData["ImplementoId"] = new SelectList(_context.Set<Implemento>(), "Id", "Id", reservaImplemento.ImplementoId);
            ViewData["ReservaId"] = new SelectList(_context.Set<Reserva>(), "ReservaId", "ReservaId", reservaImplemento.ReservaId);
            return View(reservaImplemento);
        }

        // GET: ReservaImplementos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaImplemento = await _context.ReservaImplemento
                .Include(r => r.Implemento)
                .Include(r => r.Reserva)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservaImplemento == null)
            {
                return NotFound();
            }

            return View(reservaImplemento);
        }

        // POST: ReservaImplementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaImplemento = await _context.ReservaImplemento.FindAsync(id);
            if (reservaImplemento != null)
            {
                _context.ReservaImplemento.Remove(reservaImplemento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaImplementoExists(int id)
        {
            return _context.ReservaImplemento.Any(e => e.Id == id);
        }
    }
}
