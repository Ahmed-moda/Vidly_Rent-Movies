namespace Vidly_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ubd_birth : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set BirthDate = '1/7/1998' where id=1 ");
        }
        
        public override void Down()
        {
        }
    }
}
