namespace Assignment9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        ContentType = c.String(),
                        StringId = c.String(),
                        TimeStamp = c.DateTime(nullable: false),
                        artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.artist_Id)
                .Index(t => t.artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MediaItems", "artist_Id", "dbo.Artists");
            DropIndex("dbo.MediaItems", new[] { "artist_Id" });
            DropTable("dbo.MediaItems");
        }
    }
}
