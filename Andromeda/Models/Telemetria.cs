using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andromeda.Models
{
	public class Telemetria
	{
		public int TelemetriaID { get; set; }
		[Required]
		public int VueloID { get; set; }
		[Required]
		[StringLength(40)]
		public string Variable { get; set; }
		[Required]
		public Double Valor { get; set; }

		public Vuelo Vuelo { get; set; }
	}
}