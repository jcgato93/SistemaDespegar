using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Despegar.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Despegar.Controllers
{
    public class CuartosController : Controller
    {
        // GET: Cuartos
        public ActionResult Index()

        {
            List<Cuartos> cuartos = new List<Cuartos>();

            var hotel1 = Services.CuartoService.GetCuartosHotel1();
          

            var hotel2 = Services.CuartoService.GetCuartosHotel2();
           
            if(hotel1 != null)
                cuartos.AddRange(hotel1);

            if(hotel2 != null)
                cuartos.AddRange(hotel2);

            return View(cuartos);
        }

        // GET: Cuartos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuartos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuartos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuartos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuartos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuartos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuartos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}