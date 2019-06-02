using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andromeda.Models
{
	public class Institucion
	{
		public int InstitucionID { get; set; }
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }

		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
	}
}