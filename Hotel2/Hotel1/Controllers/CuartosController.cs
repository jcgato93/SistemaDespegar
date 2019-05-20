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
    public class CuartosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CuartosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cuartos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cuartos.Include(c => c.Status).Include(c => c.TipoDeCuarto);
            return View(await applicationDbContext.ToListAsync());
        }

        
        public async Task<IActionResult> IndexJson()
        {
            var applicationDbContext = _context.Cuartos
               .Include(c => c.Status)
               .Include(c => c.TipoDeCuarto)
               .Select(x => new {
                   Id = x.Id,
                   NumeroHabitacion = x.NumeroHabitacion,
                   TipoDeCuarto = x.TipoDeCuarto.descripcion,
                   Status = x.Status.descripcion,
                   Hotel = "Hotel 2"
               });
            return Json(await applicationDbContext.ToListAsync());
        }

        // GET: Cuartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartos = await _context.Cuartos
                .Include(c => c.Status)
                .Include(c => c.TipoDeCuarto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuartos == null)
            {
                return NotFound();
            }

            return View(cuartos);
        }

        // GET: Cuartos/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "descripcion");
            ViewData["TipoDeCuartoId"] = new SelectList(_context.TipoDeCuartos, "Id", "descripcion");
            return View();
        }

        // POST: Cuartos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroHabitacion,TipoDeCuartoId,StatusId")] Cuartos cuartos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuartos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "descripcion", cuartos.StatusId);
            ViewData["TipoDeCuartoId"] = new SelectList(_context.TipoDeCuartos, "Id", "descripcion", cuartos.TipoDeCuartoId);
            return View(cuartos);
        }

        // GET: Cuartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartos = await _context.Cuartos.FindAsync(id);
            if (cuartos == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "descripcion", cuartos.StatusId);
            ViewData["TipoDeCuartoId"] = new SelectList(_context.TipoDeCuartos, "Id", "descripcion", cuartos.TipoDeCuartoId);
            return View(cuartos);
        }

        // POST: Cuartos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroHabitacion,TipoDeCuartoId,StatusId")] Cuartos cuartos)
        {
            if (id != cuartos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuartos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuartosExists(cuartos.Id))
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
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "descripcion", cuartos.StatusId);
            ViewData["TipoDeCuartoId"] = new SelectList(_context.TipoDeCuartos, "Id", "descripcion", cuartos.TipoDeCuartoId);
            return View(cuartos);
        }

        // GET: Cuartos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuartos = await _context.Cuartos
                .Include(c => c.Status)
                .Include(c => c.TipoDeCuarto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuartos == null)
            {
                return NotFound();
            }

            return View(cuartos);
        }

        // POST: Cuartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuartos = await _context.Cuartos.FindAsync(id);
            _context.Cuartos.Remove(cuartos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuartosExists(int id)
        {
            return _context.Cuartos.Any(e => e.Id == id);
        }
    }
}
