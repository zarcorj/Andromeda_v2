using Andromeda_v2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Andromeda_v2.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Andromeda_v2.Controllers
{
	public class configuracionVuelo
	{
		public Administrador Admin;
		public Experimento Exp;
		public Institucion Inst;
		public Vuelo Vue;
	}

    public class ConfiguracionVueloController : Controller
    {

		private AndromedaContext db = new AndromedaContext();

		// GET: ConfiguracionVuelo/index
		public ActionResult Index()
        {
			var listadoExperimentos = db.Experimentos.ToList();
			var listado2 = new SelectList(db.Experimentos, "ExperimentoID", "Nombre");

			ViewBag.Experimento = listadoExperimentos;
			ViewBag.Experimentos = listado2;
			ViewBag.Institucion = new SelectList(db.Instituciones, "InstitucionID", "Nombre");
			ViewBag.Administrador = new SelectList(db.Administradores, "AdministradorID", "Email");

			return View();
        }

		// POST: ConfiguracionVuelo/create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult crearVuelo([Bind(Include = "VueloID,AdministradorID,Nombre,Objetivo,Fecha,Ubicacion,Plataforma")] Vuelo vuelo, [Bind(Include = "VueloID,InstitucionID,ExperimentoID")] VueloInstitucionExperimento vue)
		{
			
			if (ModelState.IsValid)
			{
				db.Vuelos.Add(vuelo);
				db.VueloInstitucionExperimentos.Add(vue);
				db.SaveChangesAsync();
				return RedirectToAction("Index","Home");
			}
		
			ViewBag.Experimento = db.Experimentos.ToList();
			ViewBag.Institucion = new SelectList(db.Instituciones, "InstitucionID", "Nombre");
			ViewBag.Administrador = new SelectList(db.Administradores, "AdministradorID", "Email");
			return View("Index",vuelo);
		}


	}
}

/* 
 @Html.ActionLink("Edit", "edit", "markets",
	  new { id = 1 },
	  new {@class="ui-btn-right", data_icon="gear"})
	 */
