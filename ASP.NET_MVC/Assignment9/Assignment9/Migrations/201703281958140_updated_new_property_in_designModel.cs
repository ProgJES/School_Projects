namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated_new_property_in_designModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Depiction", c => c.String());
            AddColumn("dbo.Artists", "Portrayal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artists", "Portrayal");
            DropColumn("dbo.Albums", "Depiction");
        }
    }
}
