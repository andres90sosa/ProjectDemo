namespace ProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Generos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VideoJuegoes", "GeneroId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoJuegoes", "GeneroId");
            AddForeignKey("dbo.VideoJuegoes", "GeneroId", "dbo.Generoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoJuegoes", "GeneroId", "dbo.Generoes");
            DropIndex("dbo.VideoJuegoes", new[] { "GeneroId" });
            DropColumn("dbo.VideoJuegoes", "GeneroId");
            DropTable("dbo.Generoes");
        }
    }
}
