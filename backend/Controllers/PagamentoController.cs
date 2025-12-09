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
    public class PagamentoController : Controller
    {
        private readonly AppDbContext _context;

        public PagamentoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pagamentos.ToListAsync());
        }

        // GET: Pagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            return View(pagamentos);
        }

        // GET: Pagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferenciaId,UsuarioId,Metodo,DataPagamento,ValorTotal,ReferenciaTipo,CodigoTransacao,Status")] Pagamentos pagamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentos);
        }

        // GET: Pagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (pagamentos == null)
            {
                return NotFound();
            }
            return View(pagamentos);
        }

        // POST: Pagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReferenciaId,UsuarioId,Metodo,DataPagamento,ValorTotal,ReferenciaTipo,CodigoTransacao,Status")] Pagamentos pagamentos)
        {
            if (id != pagamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentosExists(pagamentos.Id))
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
            return View(pagamentos);
        }

        // GET: Pagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentos = await _context.Pagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            return View(pagamentos);
        }

        // POST: Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentos = await _context.Pagamentos.FindAsync(id);
            if (pagamentos != null)
            {
                _context.Pagamentos.Remove(pagamentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentosExists(int id)
        {
            return _context.Pagamentos.Any(e => e.Id == id);
        }
    }
}
