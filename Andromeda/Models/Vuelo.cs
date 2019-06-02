using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andromeda.Models
{
	public class Vuelo
	{
		public int VueloID { get; set; }
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }
		[Required]
		public string Objetivo { get; set; }
		public DateTime Fecha { get; set; }
		[StringLength(100)]
		public string Ubicacion { get; set; }
		[Required]
		[StringLength(50)]
		public string Plataforma { get; set; }
		
		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
		public ICollection<Telemetria> Telemetrias { get; set; }
	}
}