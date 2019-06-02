using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Andromeda_v2.DAL;
using Andromeda_v2.Models;

namespace Andromeda_v2.Controllers
{
    public class VueloController : Controller
    {
        private AndromedaContext db = new AndromedaContext();

        // GET: Vuelo
        public async Task<ActionResult> Index()
        {
            var vuelos = db.Vuelos.Include(v => v.Administrador);
            return View(await vuelos.ToListAsync());
        }

        // GET: Vuelo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = await db.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // GET: Vuelo/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorID = new SelectList(db.Administradores, "AdministradorID", "Email");
            return View();
        }

        // POST: Vuelo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VueloID,AdministradorID,Nombre,Objetivo,Fecha,Ubicacion,Plataforma")] Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Vuelos.Add(vuelo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorID = new SelectList(db.Administradores, "AdministradorID", "Email", vuelo.AdministradorID);
            return View(vuelo);
        }

		// GET: Vuelo/Configuracion_Vuelo
		public ActionResult Configuracion_Vuelo()
		{
			return View();
		}


		// GET: Vuelo/Edit/5
		public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = await db.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorID = new SelectList(db.Administradores, "AdministradorID", "Email", vuelo.AdministradorID);
            return View(vuelo);
        }

        // POST: Vuelo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VueloID,AdministradorID,Nombre,Objetivo,Fecha,Ubicacion,Plataforma")] Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vuelo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorID = new SelectList(db.Administradores, "AdministradorID", "Email", vuelo.AdministradorID);
            return View(vuelo);
        }

        // GET: Vuelo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vuelo vuelo = await db.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // POST: Vuelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vuelo vuelo = await db.Vuelos.FindAsync(id);
            db.Vuelos.Remove(vuelo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
