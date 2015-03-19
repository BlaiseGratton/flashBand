namespace Pitch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollections_on_profile_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Instruments", "Profile_ID", c => c.Int());
            AddColumn("dbo.Songs", "Profile_ID", c => c.Int());
            CreateIndex("dbo.Instruments", "Profile_ID");
            CreateIndex("dbo.Songs", "Profile_ID");
            AddForeignKey("dbo.Instruments", "Profile_ID", "dbo.Profiles", "ID");
            AddForeignKey("dbo.Songs", "Profile_ID", "dbo.Profiles", "ID");
            DropTable("dbo.UserHashes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserHashes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.Songs", "Profile_ID", "dbo.Profiles");
            DropForeignKey("dbo.Instruments", "Profile_ID", "dbo.Profiles");
            DropIndex("dbo.Songs", new[] { "Profile_ID" });
            DropIndex("dbo.Instruments", new[] { "Profile_ID" });
            DropColumn("dbo.Songs", "Profile_ID");
            DropColumn("dbo.Instruments", "Profile_ID");
            DropTable("dbo.Profiles");
        }
    }
}
