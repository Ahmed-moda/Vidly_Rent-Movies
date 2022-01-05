namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class umovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Movies", "releasedate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "nstok", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_id");
            AddForeignKey("dbo.Movies", "Genre_id", "dbo.Genres", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_id" });
            DropColumn("dbo.Movies", "Genre_id");
            DropColumn("dbo.Movies", "nstok");
            DropColumn("dbo.Movies", "releasedate");
            DropTable("dbo.Genres");
        }
    }
}
