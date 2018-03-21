namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes_in_track : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "Clerk", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Clerk", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
