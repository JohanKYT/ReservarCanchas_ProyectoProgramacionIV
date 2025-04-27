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
    public class PersonalMantenimientosController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public PersonalMantenimientosController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: PersonalMantenimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalMantenimiento.ToListAsync());
        }

        // GET: PersonalMantenimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalMantenimiento = await _context.PersonalMantenimiento
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (personalMantenimiento == null)
            {
                return NotFound();
            }

            return View(personalMantenimiento);
        }

        // GET: PersonalMantenimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalMantenimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BannerId,Nombre,Correo,Telefono,Direccion,FechaNacimiento,TipoPersona")] PersonalMantenimiento personalMantenimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalMantenimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalMantenimiento);
        }

        // GET: PersonalMantenimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalMantenimiento = await _context.PersonalMantenimiento.FindAsync(id);
            if (personalMantenimiento == null)
            {
                return NotFound();
            }
            return View(personalMantenimiento);
        }

        // POST: PersonalMantenimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BannerId,Nombre,Correo,Telefono,Direccion,FechaNacimiento,TipoPersona")] PersonalMantenimiento personalMantenimiento)
        {
            if (id != personalMantenimiento.BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalMantenimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalMantenimientoExists(personalMantenimiento.BannerId))
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
            return View(personalMantenimiento);
        }

        // GET: PersonalMantenimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalMantenimiento = await _context.PersonalMantenimiento
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (personalMantenimiento == null)
            {
                return NotFound();
            }

            return View(personalMantenimiento);
        }

        // POST: PersonalMantenimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalMantenimiento = await _context.PersonalMantenimiento.FindAsync(id);
            if (personalMantenimiento != null)
            {
                _context.PersonalMantenimiento.Remove(personalMantenimiento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalMantenimientoExists(int id)
        {
            return _context.PersonalMantenimiento.Any(e => e.BannerId == id);
        }
    }
}
