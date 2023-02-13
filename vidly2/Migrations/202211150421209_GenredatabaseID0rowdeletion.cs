namespace vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenredatabaseID0rowdeletion : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Genres WHERE Id=0");
        }
        
        public override void Down()
        {
        }
    }
}
