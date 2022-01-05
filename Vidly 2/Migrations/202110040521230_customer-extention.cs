namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerextention : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        signfree = c.Int(nullable: false),
                        discounterate = c.Int(nullable: false),
                        durationmon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Customers", "issubs", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "membertypeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "membertypeid");
            AddForeignKey("dbo.Customers", "membertypeid", "dbo.Memberships", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "membertypeid", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "membertypeid" });
            DropColumn("dbo.Customers", "membertypeid");
            DropColumn("dbo.Customers", "issubs");
            DropTable("dbo.Memberships");
        }
    }
}
