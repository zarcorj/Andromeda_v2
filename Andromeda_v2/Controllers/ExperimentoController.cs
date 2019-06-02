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
    public class ExperimentoController : Controller
    {
        private AndromedaContext db = new AndromedaContext();

        // GET: Experimento
        public async Task<ActionResult> Index()
        {
            return View(await db.Experimentos.ToListAsync());
        }

        // GET: Experimento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experimento experimento = await db.Experimentos.FindAsync(id);
            if (experimento == null)
            {
                return HttpNotFound();
            }
            return View(experimento);
        }

        // GET: Experimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExperimentoID,Nombre,Objetivo")] Experimento experimento)
        {
            if (ModelState.IsValid)
            {
                db.Experimentos.Add(experimento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(experimento);
        }

        // GET: Experimento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experimento experimento = await db.Experimentos.FindAsync(id);
            if (experimento == null)
            {
                return HttpNotFound();
            }
            return View(experimento);
        }

        // POST: Experimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExperimentoID,Nombre,Objetivo")] Experimento experimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experimento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(experimento);
        }

        // GET: Experimento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experimento experimento = await db.Experimentos.FindAsync(id);
            if (experimento == null)
            {
                return HttpNotFound();
            }
            return View(experimento);
        }

        // POST: Experimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Experimento experimento = await db.Experimentos.FindAsync(id);
            db.Experimentos.Remove(experimento);
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
