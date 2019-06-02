using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andromeda_v2.Models
{
	public class Experimento
	{
		public int ExperimentoID { get; set; }
		public string Nombre { get; set; }
		public string Objetivo { get; set; }

		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
	}
}