namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_require_from_genre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "Genre", c => c.String(nullable: false));
        }
    }
}
