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
    public class TelemetriaController : Controller
    {
        private AndromedaContext db = new AndromedaContext();

        // GET: Telemetria
        public async Task<ActionResult> Index()
        {
            var telemetrias = db.Telemetrias.Include(t => t.Vuelo);
            return View(await telemetrias.ToListAsync());
        }

        // GET: Telemetria/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetria telemetria = await db.Telemetrias.FindAsync(id);
            if (telemetria == null)
            {
                return HttpNotFound();
            }
            return View(telemetria);
        }

        // GET: Telemetria/Create
        public ActionResult Create()
        {
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre");
            return View();
        }

        // POST: Telemetria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TelemetriaID,VueloID,Nombre,Valor")] Telemetria telemetria)
        {
            if (ModelState.IsValid)
            {
                db.Telemetrias.Add(telemetria);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", telemetria.VueloID);
            return View(telemetria);
        }

        // GET: Telemetria/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetria telemetria = await db.Telemetrias.FindAsync(id);
            if (telemetria == null)
            {
                return HttpNotFound();
            }
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", telemetria.VueloID);
            return View(telemetria);
        }

        // POST: Telemetria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TelemetriaID,VueloID,Nombre,Valor")] Telemetria telemetria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telemetria).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", telemetria.VueloID);
            return View(telemetria);
        }

        // GET: Telemetria/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telemetria telemetria = await db.Telemetrias.FindAsync(id);
            if (telemetria == null)
            {
                return HttpNotFound();
            }
            return View(telemetria);
        }

        // POST: Telemetria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Telemetria telemetria = await db.Telemetrias.FindAsync(id);
            db.Telemetrias.Remove(telemetria);
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
