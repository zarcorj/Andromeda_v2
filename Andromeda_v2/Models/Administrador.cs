using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Andromeda_v2.Models
{
	public class Administrador
	{
		public int AdministradorID { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public string Contraseña { get; set; }
		public string Nombre { get; set; }
		public string Lugar_trabajo { get; set; }	// Faltante
		public int Nivel { get; set; }				// Rol

		public ICollection<Vuelo> Vuelos { get; set; }	// Faltante
	}
}