using Andromeda_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andromeda_v2.DAL
{
	public class AndromedaInitializer : System.Data.Entity.CreateDatabaseIfNotExists<AndromedaContext>
	{
		protected override void Seed(AndromedaContext context)
		{
			var instituciones = new List<Institucion>
			{
			new Institucion{InstitucionID=1, Nombre="Instituto Politécnico Nacional"},
			new Institucion{InstitucionID=2, Nombre="Centro de Desarrollo Aeroespacial"}
			};

			instituciones.ForEach(i => context.Instituciones.Add(i));
			context.SaveChanges();

			var experimentos = new List<Experimento>
			{
			new Experimento{ExperimentoID=1, Nombre="Prueba química", Objetivo="Crecer algas en el espacio"},
			new Experimento{ExperimentoID=2, Nombre="Sistema de comunicacion", Objetivo="Enviar telemetría del vehículo aeroespacial"}
			};

			experimentos.ForEach(e => context.Experimentos.Add(e));
			context.SaveChanges();

			var administradores = new List<Administrador>
			{
			new Administrador{AdministradorID=1, Email="zarcorx@gmail.com", Contraseña="cda123", Nombre="Javier Zarco", Lugar_trabajo="UPIITA-IPN", Nivel=1},
			new Administrador{AdministradorID=2, Email="espindola_ipn@hotmail.com", Contraseña="cda321", Nombre="Ariel Espindola", Lugar_trabajo="UPIITA-IPN", Nivel=1}
			};

			administradores.ForEach(ad => context.Administradores.Add(ad));
			context.SaveChanges();

			var vuelos = new List<Vuelo>
			{
			new Vuelo{VueloID=1, AdministradorID=1, Nombre="Vuelo Estratosferico Querétaro", Objetivo="Recabar datos atmosféricos", Fecha= DateTime.Parse("2018-09-01") },
			new Vuelo{VueloID=2, AdministradorID=2, Nombre="Vuelo en parapente", Objetivo="Probar sistema de transmisión de datos", Fecha= DateTime.Parse("2018-10-20") }
			};

			vuelos.ForEach(vu => context.Vuelos.Add(vu));
			context.SaveChanges();

			var telemetrias = new List<Telemetria>
			{
			new Telemetria{TelemetriaID=1, VueloID=1, Nombre="Temperatura", Valor=4.45},
			new Telemetria{TelemetriaID=2, VueloID=1, Nombre="Humedad", Valor=2.58}
			};

			telemetrias.ForEach(te => context.Telemetrias.Add(te));
			context.SaveChanges();

			var vueloInstitucionExperimentos = new List<VueloInstitucionExperimento>
			{
			new VueloInstitucionExperimento{ID=1, InstitucionID=1, VueloID=1, ExperimentoID=1},
			new VueloInstitucionExperimento{ID=2, InstitucionID=2, VueloID=2, ExperimentoID=2}
			};

			vueloInstitucionExperimentos.ForEach(vie => context.VueloInstitucionExperimentos.Add(vie));
			context.SaveChanges();
		}
	}
}