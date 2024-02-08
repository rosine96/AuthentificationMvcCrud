﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthMvc.Data;
using AuthMvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace AuthMvc.Controllers
{
    [Authorize]
    public class EnseignantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Enseignants
        public async Task<IActionResult> Index()
        {
              return _context.Enseignants != null ? 
                          View(await _context.Enseignants.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Enseignants'  is null.");
        }

        // GET: Enseignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enseignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enseignant);
        }

        // GET: Enseignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            return View(enseignant);
        }

        // POST: Enseignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Enseignant enseignant)
        {
            if (id != enseignant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Id))
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
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enseignants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Enseignants'  is null.");
            }
            var enseignant = await _context.Enseignants.FindAsync(id);
            if (enseignant != null)
            {
                _context.Enseignants.Remove(enseignant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
          return (_context.Enseignants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
