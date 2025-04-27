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
    public class CanchasController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public CanchasController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: Canchas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cancha.ToListAsync());
        }

        // GET: Canchas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .FirstOrDefaultAsync(m => m.CanchaId == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // GET: Canchas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Canchas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CanchaId,Nombre,Tipo,Disponible")] Cancha cancha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cancha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cancha);
        }

        // GET: Canchas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            return View(cancha);
        }

        // POST: Canchas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CanchaId,Nombre,Tipo,Disponible")] Cancha cancha)
        {
            if (id != cancha.CanchaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cancha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanchaExists(cancha.CanchaId))
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
            return View(cancha);
        }

        // GET: Canchas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancha = await _context.Cancha
                .FirstOrDefaultAsync(m => m.CanchaId == id);
            if (cancha == null)
            {
                return NotFound();
            }

            return View(cancha);
        }

        // POST: Canchas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cancha = await _context.Cancha.FindAsync(id);
            if (cancha != null)
            {
                _context.Cancha.Remove(cancha);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanchaExists(int id)
        {
            return _context.Cancha.Any(e => e.CanchaId == id);
        }
    }
}
