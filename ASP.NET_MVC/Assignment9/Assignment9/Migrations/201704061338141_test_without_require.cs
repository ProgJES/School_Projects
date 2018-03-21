namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_without_require : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tracks", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tracks", "Genre", c => c.String(nullable: false));
        }
    }
}
