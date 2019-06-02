using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andromeda_v2.Models
{
	public class Institucion
	{
		public int InstitucionID { get; set; }
		public string Nombre { get; set; }

		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
	}
}