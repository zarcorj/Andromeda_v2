using System.Web;
using System.Web.Optimization;

namespace Andromeda_v2
{
	public class BundleConfig
	{
		// Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/Assets/jquery").Include(
				  "~/Assets/js/jquery-3.3.1.min.js"));

			bundles.Add(new ScriptBundle("~/Assets/jqueryval").Include(
						"~/Assets/js/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Assets/js/jquery.validate*"));

			// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
			// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
			bundles.Add(new ScriptBundle("~/Assets/modernizr").Include(
						"~/Assets/js/modernizr-*"));

			bundles.Add(new ScriptBundle("~/Assets/bootstrap").Include(
					  "~/Assets/js/bootstrap.min.js"));

			bundles.Add(new ScriptBundle("~/Assets/utils").Include(
					  "~/Assets/js/jquery.dropotron.min.js",
					  "~/Assets/js/browser.min.js",
					  "~/Assets/js/breakpoints.min.js",
					  "~/Assets/js/util.js",
					  "~/Assets/js/main.js"));

			bundles.Add(new ScriptBundle("~/Assets/tables").Include(
					  "~/Assets/tables/js/jquery-3.3.1.min.js",
					  "~/Assets/tables/js/bootstrap.min.js",
					  "~/Assets/tables/js/addons/datatables.min.js"));

			// Highchart graphs
			bundles.Add(new ScriptBundle("~/Assets/graphs/highcharts").Include(
					  "~/Assets/graphs/highcharts.js",
					  "~/Assets/graphs/modules/exporting.js",
					  "~/Assets/graphs/modules/export-data.js",
					  "~/Assets/graphs/modules/data.js",
					  "~/Assets/graphs/modules/series-label.js"));
			
			// Canvas graphs
			bundles.Add(new ScriptBundle("~/Assets/graphs/canvas").Include(
					  "~/Assets/js/canvasjs.min.js"));

			bundles.Add(new StyleBundle("~/Assets/tables/css").Include(
					  "~/Assets/tables/css/addons/bootstrap.min.css"));

			bundles.Add(new StyleBundle("~/Assets/css").Include(
					  "~/Assets/css/bootstrap.min.css",
					  "~/Assets/css/mainIndex.css"));
		}
	}
}
