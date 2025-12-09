using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Controllers
{
    public class AssentosController : Controller
    {
        private readonly AppDbContext _context;

        public AssentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Assentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assentos.ToListAsync());
        }

        // GET: Assentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentos = await _context.Assentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assentos == null)
            {
                return NotFound();
            }

            return View(assentos);
        }

        // GET: Assentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalaId,Fileira,Coluna,Tipo,Status")] Assentos assentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assentos);
        }

        // GET: Assentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentos = await _context.Assentos.FindAsync(id);
            if (assentos == null)
            {
                return NotFound();
            }
            return View(assentos);
        }

        // POST: Assentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalaId,Fileira,Coluna,Tipo,Status")] Assentos assentos)
        {
            if (id != assentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssentosExists(assentos.Id))
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
            return View(assentos);
        }

        // GET: Assentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assentos = await _context.Assentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assentos == null)
            {
                return NotFound();
            }

            return View(assentos);
        }

        // POST: Assentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assentos = await _context.Assentos.FindAsync(id);
            if (assentos != null)
            {
                _context.Assentos.Remove(assentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssentosExists(int id)
        {
            return _context.Assentos.Any(e => e.Id == id);
        }
    }
}
