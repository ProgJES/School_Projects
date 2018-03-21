namespace Assignment8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "BirthName", c => c.String());
            AddColumn("dbo.Tracks", "Clerk", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "Clerk");
            DropColumn("dbo.Artists", "BirthName");
        }
    }
}
