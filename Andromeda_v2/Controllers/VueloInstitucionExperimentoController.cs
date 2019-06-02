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
    public class VueloInstitucionExperimentoController : Controller
    {
        private AndromedaContext db = new AndromedaContext();

		// GET: VueloInstitucionExperimento
		public async Task<ActionResult> Index()
        {
            var vueloInstitucionExperimentos = db.VueloInstitucionExperimentos.Include(v => v.Experimento).Include(v => v.Institucion).Include(v => v.Vuelo);
            return View(await vueloInstitucionExperimentos.ToListAsync());
        }

        // GET: VueloInstitucionExperimento/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VueloInstitucionExperimento vueloInstitucionExperimento = await db.VueloInstitucionExperimentos.FindAsync(id);
            if (vueloInstitucionExperimento == null)
            {
                return HttpNotFound();
            }
            return View(vueloInstitucionExperimento);
        }

        // GET: VueloInstitucionExperimento/Create
        public ActionResult Create()
        {
            ViewBag.ExperimentoID = new SelectList(db.Experimentos, "ExperimentoID", "Nombre");
            ViewBag.InstitucionID = new SelectList(db.Instituciones, "InstitucionID", "Nombre");
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre");
            return View();
        }

        // POST: VueloInstitucionExperimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,InstitucionID,VueloID,ExperimentoID")] VueloInstitucionExperimento vueloInstitucionExperimento)
        {
            if (ModelState.IsValid)
            {
                db.VueloInstitucionExperimentos.Add(vueloInstitucionExperimento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExperimentoID = new SelectList(db.Experimentos, "ExperimentoID", "Nombre", vueloInstitucionExperimento.ExperimentoID);
            ViewBag.InstitucionID = new SelectList(db.Instituciones, "InstitucionID", "Nombre", vueloInstitucionExperimento.InstitucionID);
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", vueloInstitucionExperimento.VueloID);
            return View(vueloInstitucionExperimento);
        }

        // GET: VueloInstitucionExperimento/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VueloInstitucionExperimento vueloInstitucionExperimento = await db.VueloInstitucionExperimentos.FindAsync(id);
            if (vueloInstitucionExperimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExperimentoID = new SelectList(db.Experimentos, "ExperimentoID", "Nombre", vueloInstitucionExperimento.ExperimentoID);
            ViewBag.InstitucionID = new SelectList(db.Instituciones, "InstitucionID", "Nombre", vueloInstitucionExperimento.InstitucionID);
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", vueloInstitucionExperimento.VueloID);
            return View(vueloInstitucionExperimento);
        }

        // POST: VueloInstitucionExperimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,InstitucionID,VueloID,ExperimentoID")] VueloInstitucionExperimento vueloInstitucionExperimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vueloInstitucionExperimento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExperimentoID = new SelectList(db.Experimentos, "ExperimentoID", "Nombre", vueloInstitucionExperimento.ExperimentoID);
            ViewBag.InstitucionID = new SelectList(db.Instituciones, "InstitucionID", "Nombre", vueloInstitucionExperimento.InstitucionID);
            ViewBag.VueloID = new SelectList(db.Vuelos, "VueloID", "Nombre", vueloInstitucionExperimento.VueloID);
            return View(vueloInstitucionExperimento);
        }

        // GET: VueloInstitucionExperimento/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VueloInstitucionExperimento vueloInstitucionExperimento = await db.VueloInstitucionExperimentos.FindAsync(id);
            if (vueloInstitucionExperimento == null)
            {
                return HttpNotFound();
            }
            return View(vueloInstitucionExperimento);
        }

        // POST: VueloInstitucionExperimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VueloInstitucionExperimento vueloInstitucionExperimento = await db.VueloInstitucionExperimentos.FindAsync(id);
            db.VueloInstitucionExperimentos.Remove(vueloInstitucionExperimento);
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
