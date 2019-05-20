using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel1.Context;
using Hotel1.Entity;

namespace Hotel1.Controllers
{
    public class TipoDeCuartoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDeCuartoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoDeCuartoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDeCuartos.ToListAsync());
        }

        // GET: TipoDeCuartoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCuarto = await _context.TipoDeCuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeCuarto == null)
            {
                return NotFound();
            }

            return View(tipoDeCuarto);
        }

        // GET: TipoDeCuartoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDeCuartoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,descripcion")] TipoDeCuarto tipoDeCuarto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDeCuarto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDeCuarto);
        }

        // GET: TipoDeCuartoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCuarto = await _context.TipoDeCuartos.FindAsync(id);
            if (tipoDeCuarto == null)
            {
                return NotFound();
            }
            return View(tipoDeCuarto);
        }

        // POST: TipoDeCuartoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,descripcion")] TipoDeCuarto tipoDeCuarto)
        {
            if (id != tipoDeCuarto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDeCuarto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDeCuartoExists(tipoDeCuarto.Id))
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
            return View(tipoDeCuarto);
        }

        // GET: TipoDeCuartoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDeCuarto = await _context.TipoDeCuartos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDeCuarto == null)
            {
                return NotFound();
            }

            return View(tipoDeCuarto);
        }

        // POST: TipoDeCuartoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDeCuarto = await _context.TipoDeCuartos.FindAsync(id);
            _context.TipoDeCuartos.Remove(tipoDeCuarto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDeCuartoExists(int id)
        {
            return _context.TipoDeCuartos.Any(e => e.Id == id);
        }
    }
}
