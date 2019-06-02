using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andromeda.Models
{
	public class Experimento
	{
		public int ExperimentoID { get; set; }
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }
		[Required]
		public string Objetivo { get; set; }

		public ICollection<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }
	}
}