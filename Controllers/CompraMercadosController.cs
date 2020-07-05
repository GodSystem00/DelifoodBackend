using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Delifood.Data;
using Delifood.Models;

namespace Delifood.Controllers
{
    public class CompraMercadosController : Controller
    {
        private readonly DelifoodContext _context;

        public CompraMercadosController(DelifoodContext context)
        {
            _context = context;
        }

        // GET: CompraMercados
        public async Task<IActionResult> Index()
        {
            var delifoodContext = _context.CompraMercados.Include(c => c.Compra).Include(c => c.Mercado);
            return View(await delifoodContext.ToListAsync());
        }

        // GET: CompraMercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraMercado = await _context.CompraMercados
                .Include(c => c.Compra)
                .Include(c => c.Mercado)
                .FirstOrDefaultAsync(m => m.CompraMercadoID == id);
            if (compraMercado == null)
            {
                return NotFound();
            }

            return View(compraMercado);
        }

        // GET: CompraMercados/Create
        public IActionResult Create()
        {
            ViewData["CompraID"] = new SelectList(_context.Compras, "CompraID", "CompraID");
            ViewData["MercadoID"] = new SelectList(_context.Mercados, "MercadoID", "MercadoID");
            return View();
        }

        // POST: CompraMercados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompraMercadoID,CompraID,MercadoID")] CompraMercado compraMercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compraMercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompraID"] = new SelectList(_context.Compras, "CompraID", "CompraID", compraMercado.CompraID);
            ViewData["MercadoID"] = new SelectList(_context.Mercados, "MercadoID", "MercadoID", compraMercado.MercadoID);
            return View(compraMercado);
        }

        // GET: CompraMercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraMercado = await _context.CompraMercados.FindAsync(id);
            if (compraMercado == null)
            {
                return NotFound();
            }
            ViewData["CompraID"] = new SelectList(_context.Compras, "CompraID", "CompraID", compraMercado.CompraID);
            ViewData["MercadoID"] = new SelectList(_context.Mercados, "MercadoID", "MercadoID", compraMercado.MercadoID);
            return View(compraMercado);
        }

        // POST: CompraMercados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompraMercadoID,CompraID,MercadoID")] CompraMercado compraMercado)
        {
            if (id != compraMercado.CompraMercadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraMercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraMercadoExists(compraMercado.CompraMercadoID))
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
            ViewData["CompraID"] = new SelectList(_context.Compras, "CompraID", "CompraID", compraMercado.CompraID);
            ViewData["MercadoID"] = new SelectList(_context.Mercados, "MercadoID", "MercadoID", compraMercado.MercadoID);
            return View(compraMercado);
        }

        // GET: CompraMercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraMercado = await _context.CompraMercados
                .Include(c => c.Compra)
                .Include(c => c.Mercado)
                .FirstOrDefaultAsync(m => m.CompraMercadoID == id);
            if (compraMercado == null)
            {
                return NotFound();
            }

            return View(compraMercado);
        }

        // POST: CompraMercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraMercado = await _context.CompraMercados.FindAsync(id);
            _context.CompraMercados.Remove(compraMercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraMercadoExists(int id)
        {
            return _context.CompraMercados.Any(e => e.CompraMercadoID == id);
        }
    }
}
