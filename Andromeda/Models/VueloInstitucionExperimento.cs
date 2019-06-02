namespace Andromeda.Models
{
	public class VueloInstitucionExperimento
	{
		public int ID { get; set; }
		public int InstitucionID { get; set; }
		public int VueloID { get; set; }
		public int ExperimentoID { get; set; }

		public virtual Institucion Institucion { get; set; }
		public virtual Vuelo Vuelo { get; set; }
		public virtual Experimento Experimento { get; set; }
	}
}