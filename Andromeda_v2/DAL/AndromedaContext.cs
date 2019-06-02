using Andromeda_v2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Andromeda_v2.DAL
{
	public class AndromedaContext : DbContext
	{
		public AndromedaContext() : base("Andromeda_v2")
		{
		}
		//4ndromedA&
		public DbSet<Institucion> Instituciones { get; set; }
		public DbSet<Experimento> Experimentos { get; set; }
		public DbSet<Administrador> Administradores { get; set; }
		public DbSet<Vuelo> Vuelos { get; set; }
		public DbSet<Telemetria> Telemetrias { get; set; }
		public DbSet<VueloInstitucionExperimento> VueloInstitucionExperimentos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}