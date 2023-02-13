namespace vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) values(1,'Comedy')");
           
           
        }
        
        public override void Down()
        {
        }
    }
}
