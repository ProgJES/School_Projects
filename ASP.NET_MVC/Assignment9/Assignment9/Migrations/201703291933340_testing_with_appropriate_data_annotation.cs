namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing_with_appropriate_data_annotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artists", "Genre", c => c.String());
            AlterColumn("dbo.Artists", "Executive", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artists", "Executive", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Artists", "Genre", c => c.String(nullable: false));
        }
    }
}
