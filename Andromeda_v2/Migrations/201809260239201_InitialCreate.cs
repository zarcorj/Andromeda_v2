namespace Andromeda_v2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        AdministradorID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Contraseña = c.String(),
                        Nombre = c.String(),
                        Lugar_trabajo = c.String(),
                        Nivel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdministradorID);
            
            CreateTable(
                "dbo.Vuelo",
                c => new
                    {
                        VueloID = c.Int(nullable: false, identity: true),
                        AdministradorID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Objetivo = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Ubicacion = c.String(),
                        Plataforma = c.String(),
                    })
                .PrimaryKey(t => t.VueloID)
                .ForeignKey("dbo.Administrador", t => t.AdministradorID, cascadeDelete: true)
                .Index(t => t.AdministradorID);
            
            CreateTable(
                "dbo.Telemetria",
                c => new
                    {
                        TelemetriaID = c.Int(nullable: false, identity: true),
                        VueloID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TelemetriaID)
                .ForeignKey("dbo.Vuelo", t => t.VueloID, cascadeDelete: true)
                .Index(t => t.VueloID);
            
            CreateTable(
                "dbo.VueloInstitucionExperimento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InstitucionID = c.Int(nullable: false),
                        VueloID = c.Int(nullable: false),
                        ExperimentoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Experimento", t => t.ExperimentoID, cascadeDelete: true)
                .ForeignKey("dbo.Institucion", t => t.InstitucionID, cascadeDelete: true)
                .ForeignKey("dbo.Vuelo", t => t.VueloID, cascadeDelete: true)
                .Index(t => t.InstitucionID)
                .Index(t => t.VueloID)
                .Index(t => t.ExperimentoID);
            
            CreateTable(
                "dbo.Experimento",
                c => new
                    {
                        ExperimentoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Objetivo = c.String(),
                    })
                .PrimaryKey(t => t.ExperimentoID);
            
            CreateTable(
                "dbo.Institucion",
                c => new
                    {
                        InstitucionID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.InstitucionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VueloInstitucionExperimento", "VueloID", "dbo.Vuelo");
            DropForeignKey("dbo.VueloInstitucionExperimento", "InstitucionID", "dbo.Institucion");
            DropForeignKey("dbo.VueloInstitucionExperimento", "ExperimentoID", "dbo.Experimento");
            DropForeignKey("dbo.Telemetria", "VueloID", "dbo.Vuelo");
            DropForeignKey("dbo.Vuelo", "AdministradorID", "dbo.Administrador");
            DropIndex("dbo.VueloInstitucionExperimento", new[] { "ExperimentoID" });
            DropIndex("dbo.VueloInstitucionExperimento", new[] { "VueloID" });
            DropIndex("dbo.VueloInstitucionExperimento", new[] { "InstitucionID" });
            DropIndex("dbo.Telemetria", new[] { "VueloID" });
            DropIndex("dbo.Vuelo", new[] { "AdministradorID" });
            DropTable("dbo.Institucion");
            DropTable("dbo.Experimento");
            DropTable("dbo.VueloInstitucionExperimento");
            DropTable("dbo.Telemetria");
            DropTable("dbo.Vuelo");
            DropTable("dbo.Administrador");
        }
    }
}
