using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Despegar.Context;
using Despegar.Entity;
using System.Security.Claims;
using Despegar.Services;
using Microsoft.AspNetCore.Authorization;

namespace Despegar.Controllers
{
    [Authorize]
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var applicationDbContext = _context.Reservas.Include(r => r.Cliente)
                .Where(x => x.ClienteId.Equals(userId));

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create(int id, string hotel, int precio)
        {
            Despegar.Entity.Reserva reserva = new Reserva();

            reserva.CuartoId = id;
            reserva.Hotel = hotel;
            reserva.Precio = precio;

            ViewData["ClienteId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CuartoId,Precio,FechaReserva,DiasReserva,CantidadPersonas,ClienteId,IdentificacionCliente,Hotel,Status,ReservaId,TotalPago,FechaVencimiento,CVC")] Reserva reserva)
        {
            int? reservaId = null;
            if (ModelState.IsValid)
            {
                reserva.TotalPago = reserva.Precio * reserva.DiasReserva;

                if(reserva.Hotel.Equals("Hotel 1"))
                {
                  reservaId= CuartoService.SaveReservaHotel1(reserva);
                }
                else if (reserva.Hotel.Equals("Hotel 2"))
                {
                    reservaId = CuartoService.SaveReservaHotel2(reserva);
                }

                if (reservaId != null)
                {
                    reserva.ReservaId = (int)reservaId;
                    _context.Add(reserva);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "Id", "Id", reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Users, "Id", "Id", reserva.ClienteId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CuartoId,Precio,FechaReserva,DiasReserva,CantidadPersonas,ClienteId,IdentificacionCliente,Hotel,Status,ReservaId,TotalPago,FechaVencimiento,CVC")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Users, "Id", "Id", reserva.ClienteId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool resultDelete = false;
            var reserva = await _context.Reservas.FindAsync(id);
            //_context.Reservas.Remove(reserva);
            //await _context.SaveChangesAsync();
            if (reserva.Hotel.Equals("Hotel 1"))
            {
                resultDelete = CuartoService.DeleteReservaHotel1(reserva.Id);
            }
            else if (reserva.Hotel.Equals("Hotel 2"))
            {
                resultDelete = CuartoService.DeleteReservaHotel2(reserva.Id);
            }


            if (resultDelete)
            {
                reserva.Status = "Cancelada";
                _context.Update(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
