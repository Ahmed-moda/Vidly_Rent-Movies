namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatename : DbMigration
    {
        public override void Up()
        {
            Sql("update Memberships set Name = 'Pay when you go' where id=1 ");
            Sql("update Memberships set Name = 'Monthly' where id=2 ");
            Sql("update Memberships set Name = 'Quarter' where id=3 ");
            Sql("update Memberships set Name = 'Yearly' where id=4 ");
        }
        
        public override void Down()
        {
        }
    }
}
