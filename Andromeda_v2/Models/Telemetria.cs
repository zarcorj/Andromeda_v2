using System;

namespace Andromeda_v2.Models
{
	public class Telemetria
	{
		public int TelemetriaID { get; set; }
		public int VueloID { get; set; }
		public string Nombre { get; set; }
		public Double Valor { get; set; }

		public Vuelo Vuelo { get; set; }
	}
}