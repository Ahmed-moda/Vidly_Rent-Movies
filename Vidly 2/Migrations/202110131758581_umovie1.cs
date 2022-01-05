namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class umovie1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "Genre_id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_id" });
            RenameColumn(table: "dbo.Movies", name: "Genre_id", newName: "Genreid");
            AlterColumn("dbo.Movies", "Genreid", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genreid");
            AddForeignKey("dbo.Movies", "Genreid", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genreid", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genreid" });
            AlterColumn("dbo.Movies", "Genreid", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "Genreid", newName: "Genre_id");
            CreateIndex("dbo.Movies", "Genre_id");
            AddForeignKey("dbo.Movies", "Genre_id", "dbo.Genres", "id");
        }
    }
}
