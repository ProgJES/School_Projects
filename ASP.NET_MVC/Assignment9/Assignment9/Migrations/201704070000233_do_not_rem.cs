namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class do_not_rem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MediaItems", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MediaItems", "Caption");
        }
    }
}
