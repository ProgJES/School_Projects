namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class back_to_nomal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "Genre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "Genre", c => c.String());
        }
    }
}
