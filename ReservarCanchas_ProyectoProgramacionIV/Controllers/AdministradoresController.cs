﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservarCanchas_ProyectoProgramacionIV.Models;

namespace ReservarCanchas_ProyectoProgramacionIV.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly BaseDatos_ReservarCanchas_ProyectoProgramacionIV _context;

        public AdministradoresController(BaseDatos_ReservarCanchas_ProyectoProgramacionIV context)
        {
            _context = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
            var baseDatos_ReservarCanchas_ProyectoProgramacionIV = _context.Administrador.Include(a => a.Facultad);
            return View(await baseDatos_ReservarCanchas_ProyectoProgramacionIV.ToListAsync());
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.Facultad)
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            ViewData["FacultadId"] = new SelectList(_context.Set<Facultad>(), "Id", "Nombre");
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultadId,BannerId,Nombre,Correo,Password,Telefono,Direccion,FechaNacimiento,TipoPersona")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Administrador creado correctamente c:";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultadId"] = new SelectList(_context.Set<Facultad>(), "Id", "Nombre", administrador.FacultadId);
            return View(administrador);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            ViewData["FacultadId"] = new SelectList(_context.Facultad, "Id", "Nombre", administrador.FacultadId);
            return View(administrador);
        }

            // POST: Administradores/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacultadId,BannerId,Nombre,Correo,Password,Telefono,Direccion,FechaNacimiento,TipoPersona")] Administrador administrador)
        {
            if (id != administrador.BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.BannerId))
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
            ViewData["FacultadId"] = new SelectList(_context.Set<Facultad>(), "Id", "Nombre", administrador.FacultadId);
            return View(administrador);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administrador
                .Include(a => a.Facultad)
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administrador.FindAsync(id);
            if (administrador != null)
            {
                _context.Administrador.Remove(administrador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administrador.Any(e => e.BannerId == id);
        }
    }
}
