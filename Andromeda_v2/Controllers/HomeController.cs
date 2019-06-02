using Andromeda_v2.DAL;
using Andromeda_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Andromeda_v2.Controllers
{
	public class HomeController : Controller
	{
		private AndromedaContext db = new AndromedaContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Descripción de aplicación.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Página de contacto";

			return View();
		}

		public ActionResult Inicio_Sesion()
		{
			ViewBag.Message = "Inicio Sesión";

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Inicio_Sesion(Administrador administrador)
		{

			var admin = db.Database.SqlQuery<Administrador>(
				@"Select *
					FROM dbo.Administrador
					WHERE Email = @email and Contraseña = @contrasenia", 
					new SqlParameter("@email", administrador.Email), 
					new SqlParameter("@contrasenia", administrador.Contraseña)).FirstOrDefault();

			if (admin == null)
			{
				Console.Write(admin);
			}

			return View(admin);
		}

	}
}