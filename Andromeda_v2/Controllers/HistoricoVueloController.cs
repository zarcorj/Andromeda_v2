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
    public class HistoricoVueloController : Controller
    {
		private AndromedaContext db = new AndromedaContext();

		// GET: HistoricoVuelo/Index
		public ActionResult Index()
        {
			var vueloInstitucionExperimentos = db.VueloInstitucionExperimentos.Include(v => v.Experimento).Include(v => v.Institucion).Include(v => v.Vuelo);
			return View(vueloInstitucionExperimentos.ToList());
		}

		// POST: Historico/Vuelo/ID
		public ActionResult Details(int ID)
		{
			VueloInstitucionExperimento vue = db.VueloInstitucionExperimentos.Find(ID);
			return View(vue);
		}

	}
}
