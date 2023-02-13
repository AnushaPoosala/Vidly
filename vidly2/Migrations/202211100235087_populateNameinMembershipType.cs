namespace vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateNameinMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='PayAsYouGo' WHERE DurationInMonths=0");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE DurationInMonths=1");
            Sql("UPDATE MembershipTypes SET Name='Quartely' WHERE DurationInMonths=3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' WHERE DurationInMonths=12");

        }
        
        public override void Down()
        {
        }
    }
}
