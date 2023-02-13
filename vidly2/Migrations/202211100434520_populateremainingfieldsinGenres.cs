namespace vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateremainingfieldsinGenres : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id,Name) values(2,'Action')");
            Sql("Insert into Genres (Id,Name) values(3,'Action')");
            Sql("Insert into Genres (Id,Name) values(4,'Family')");
            Sql("Insert into Genres (Id,Name) values(5,'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
