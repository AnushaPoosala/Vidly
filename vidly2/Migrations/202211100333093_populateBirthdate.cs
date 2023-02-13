namespace vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set Birthdate='1994-09-06' where Id=3");
        }
        
        public override void Down()
        {
        }
    }
}
