using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class CaixasController : Controller
    {
        private readonly Contexto _context;

        public CaixasController(Contexto context)
        {
            _context = context;
        }

        // GET: Caixas
        public async Task<IActionResult> Index()
        {
              return _context.Caixas != null ? 
                          View(await _context.Caixas.ToListAsync()) :
                          Problem("Entity set 'Contexto.Caixas'  is null.");
        }

        // GET: Caixas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Caixas == null)
            {
                return NotFound();
            }

            var fechamentoCaixa = await _context.Caixas
                .FirstOrDefaultAsync(m => m.FechamentoID == id);
            if (fechamentoCaixa == null)
            {
                return NotFound();
            }

            return View(fechamentoCaixa);
        }

        // GET: Caixas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Caixas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechamentoID,DataFechamento,ValorInicial,ValorFinal")] FechamentoCaixa fechamentoCaixa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fechamentoCaixa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fechamentoCaixa);
        }

        // GET: Caixas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Caixas == null)
            {
                return NotFound();
            }

            var fechamentoCaixa = await _context.Caixas.FindAsync(id);
            if (fechamentoCaixa == null)
            {
                return NotFound();
            }
            return View(fechamentoCaixa);
        }

        // POST: Caixas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechamentoID,DataFechamento,ValorInicial,ValorFinal")] FechamentoCaixa fechamentoCaixa)
        {
            if (id != fechamentoCaixa.FechamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fechamentoCaixa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FechamentoCaixaExists(fechamentoCaixa.FechamentoID))
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
            return View(fechamentoCaixa);
        }

        // GET: Caixas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Caixas == null)
            {
                return NotFound();
            }

            var fechamentoCaixa = await _context.Caixas
                .FirstOrDefaultAsync(m => m.FechamentoID == id);
            if (fechamentoCaixa == null)
            {
                return NotFound();
            }

            return View(fechamentoCaixa);
        }

        // POST: Caixas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Caixas == null)
            {
                return Problem("Entity set 'Contexto.Caixas'  is null.");
            }
            var fechamentoCaixa = await _context.Caixas.FindAsync(id);
            if (fechamentoCaixa != null)
            {
                _context.Caixas.Remove(fechamentoCaixa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FechamentoCaixaExists(int id)
        {
          return (_context.Caixas?.Any(e => e.FechamentoID == id)).GetValueOrDefault();
        }
    }
}
