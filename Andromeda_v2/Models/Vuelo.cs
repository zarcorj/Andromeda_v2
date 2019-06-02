using System;
using System.Collections.Generic;

namespace Andromeda_v2.Models
{
	public class Vuelo
	{
		public int VueloID { get; set; }
		public int AdministradorID { get; set; }
		public string Nombre { get; set; }
		public string Objetivo { get; set; }
		public DateTime Fecha { get; set; }
		public string Ubicacion { get; set; }
		public string Plataforma { get; set; }

		public virtual Administrador Administrador { get; set; }
		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
		public ICollection<Telemetria> Telemetrias { get; set; }
	}
}