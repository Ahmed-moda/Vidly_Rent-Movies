namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upmem : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "membertypeid", newName: "Membershipid");
            RenameIndex(table: "dbo.Customers", name: "IX_membertypeid", newName: "IX_Membershipid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_Membershipid", newName: "IX_membertypeid");
            RenameColumn(table: "dbo.Customers", name: "Membershipid", newName: "membertypeid");
        }
    }
}
