namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertmembershhip : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT dbo.Memberships ON");
            Sql("insert into Memberships(id,signfree,discounterate,durationmon)values(1,0,0,0)");
            Sql("insert into Memberships(id,signfree,discounterate,durationmon)values(2,30,10,1)");
            Sql("insert into Memberships(id,signfree,discounterate,durationmon)values(3,90,15,3)");
            Sql("insert into Memberships(id,signfree,discounterate,durationmon)values(4,300,20,12)");
        }
        
        public override void Down()
        {
        }
    }
}
