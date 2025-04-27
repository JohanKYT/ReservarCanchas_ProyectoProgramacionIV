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
    public class ImplementosController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public ImplementosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: Implementos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Implemento.ToListAsync());
        }

        // GET: Implementos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implemento = await _context.Implemento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (implemento == null)
            {
                return NotFound();
            }

            return View(implemento);
        }

        // GET: Implementos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Implementos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CantidadTotal,CantidadDisponible,Estado")] Implemento implemento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(implemento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(implemento);
        }

        // GET: Implementos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implemento = await _context.Implemento.FindAsync(id);
            if (implemento == null)
            {
                return NotFound();
            }
            return View(implemento);
        }

        // POST: Implementos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CantidadTotal,CantidadDisponible,Estado")] Implemento implemento)
        {
            if (id != implemento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(implemento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImplementoExists(implemento.Id))
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
            return View(implemento);
        }

        // GET: Implementos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var implemento = await _context.Implemento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (implemento == null)
            {
                return NotFound();
            }

            return View(implemento);
        }

        // POST: Implementos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var implemento = await _context.Implemento.FindAsync(id);
            if (implemento != null)
            {
                _context.Implemento.Remove(implemento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImplementoExists(int id)
        {
            return _context.Implemento.Any(e => e.Id == id);
        }
    }
}
