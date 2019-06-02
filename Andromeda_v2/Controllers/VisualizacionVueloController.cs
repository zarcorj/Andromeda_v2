using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net;
using Andromeda_v2.DAL;
using Andromeda_v2.Models;

namespace Andromeda_v2.Controllers
{
    public class VisualizacionVueloController : Controller
    {
		private AndromedaContext db = new AndromedaContext();

		// GET: VisualizacionVuelo/index
		public ActionResult index()
		{
			return View();
		}

    }
}