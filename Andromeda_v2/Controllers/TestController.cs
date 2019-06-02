using Andromeda_v2.DAL;
using Andromeda_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Andromeda_v2.Controllers
{
    public class TestController : Controller
    {
		private AndromedaContext db = new AndromedaContext();

		public class vueloCompleto
		{
			public Vuelo vuelo { get; set; }
			public Administrador admin { get; set; }
			public Institucion institucion { get; set; }
			public Experimento experimento { get; set; }
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

		// GET: VueloInstitucionExperimento
		public async Task<ActionResult> Index()
		{
			var vueloInstitucionExperimentos = db.VueloInstitucionExperimentos.Include(v => v.Experimento).Include(v => v.Institucion).Include(v => v.Vuelo);
			return View(await vueloInstitucionExperimentos.ToListAsync());
		}

		[HttpGet]
		// GET: Test/VueloCompleto
		public ActionResult VueloCompleto()
		{
			var vueloInstitucionExperimentos = db.VueloInstitucionExperimentos.Include(v => v.Experimento).Include(v => v.Institucion).Include(v => v.Vuelo);
			return View(vueloInstitucionExperimentos.ToList());
		}


    }
}