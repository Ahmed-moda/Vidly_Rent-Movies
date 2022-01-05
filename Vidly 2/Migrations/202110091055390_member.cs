namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class member : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Name", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Name");
        }
    }
}
