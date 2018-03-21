namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what_did_i_do : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tracks", "ContentType");
        }
    }
}
