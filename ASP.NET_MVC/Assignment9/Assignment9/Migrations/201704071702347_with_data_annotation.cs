namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class with_data_annotation : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MediaItems", new[] { "artist_Id" });
            AlterColumn("dbo.MediaItems", "ContentType", c => c.String(maxLength: 100));
            AlterColumn("dbo.MediaItems", "StringId", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.MediaItems", "artist_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MediaItems", "artist_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MediaItems", new[] { "artist_Id" });
            AlterColumn("dbo.MediaItems", "artist_Id", c => c.Int());
            AlterColumn("dbo.MediaItems", "StringId", c => c.String());
            AlterColumn("dbo.MediaItems", "ContentType", c => c.String());
            CreateIndex("dbo.MediaItems", "artist_Id");
        }
    }
}
