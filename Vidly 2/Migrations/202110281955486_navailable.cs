namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class navailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "navailable", c => c.Int(nullable: false));

            Sql("update movies set navailable = nstok");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "navailable");
        }
    }
}
