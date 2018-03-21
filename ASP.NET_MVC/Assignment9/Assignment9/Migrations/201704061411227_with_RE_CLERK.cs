namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class with_RE_CLERK : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "Clerk", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Clerk", c => c.String());
        }
    }
}
