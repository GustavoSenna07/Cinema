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
    public class IngressosController : Controller
    {
        private readonly AppDbContext _context;

        public IngressosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ingressos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingressos.ToListAsync());
        }

        // GET: Ingressos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingressos == null)
            {
                return NotFound();
            }

            return View(ingressos);
        }

        // GET: Ingressos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingressos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,SessaoId,AssentoId,TipoIngresso,Status,DataCompra,ValorTotal")] Ingressos ingressos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingressos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingressos);
        }

        // GET: Ingressos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos.FindAsync(id);
            if (ingressos == null)
            {
                return NotFound();
            }
            return View(ingressos);
        }

        // POST: Ingressos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,SessaoId,AssentoId,TipoIngresso,Status,DataCompra,ValorTotal")] Ingressos ingressos)
        {
            if (id != ingressos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingressos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressosExists(ingressos.Id))
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
            return View(ingressos);
        }

        // GET: Ingressos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingressos = await _context.Ingressos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingressos == null)
            {
                return NotFound();
            }

            return View(ingressos);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingressos = await _context.Ingressos.FindAsync(id);
            if (ingressos != null)
            {
                _context.Ingressos.Remove(ingressos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressosExists(int id)
        {
            return _context.Ingressos.Any(e => e.Id == id);
        }
    }
}
