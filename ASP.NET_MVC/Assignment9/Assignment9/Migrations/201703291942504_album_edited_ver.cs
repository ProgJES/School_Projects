namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class album_edited_ver : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "Genre", c => c.String());
            AlterColumn("dbo.Albums", "Coordinator", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "Coordinator", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Albums", "Genre", c => c.String(nullable: false));
        }
    }
}
