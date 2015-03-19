namespace Pitch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Many_to_many_attempt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Instruments", "Profile_ID", "dbo.Profiles");
            DropForeignKey("dbo.Songs", "Profile_ID", "dbo.Profiles");
            DropIndex("dbo.Instruments", new[] { "Profile_ID" });
            DropIndex("dbo.Songs", new[] { "Profile_ID" });
            CreateTable(
                "dbo.ProfileInstruments",
                c => new
                    {
                        Profile_ID = c.Int(nullable: false),
                        Instrument_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ID, t.Instrument_ID })
                .ForeignKey("dbo.Profiles", t => t.Profile_ID, cascadeDelete: true)
                .ForeignKey("dbo.Instruments", t => t.Instrument_ID, cascadeDelete: true)
                .Index(t => t.Profile_ID)
                .Index(t => t.Instrument_ID);
            
            CreateTable(
                "dbo.SongProfiles",
                c => new
                    {
                        Song_ID = c.Int(nullable: false),
                        Profile_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Song_ID, t.Profile_ID })
                .ForeignKey("dbo.Songs", t => t.Song_ID, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_ID, cascadeDelete: true)
                .Index(t => t.Song_ID)
                .Index(t => t.Profile_ID);
            
            DropColumn("dbo.Instruments", "Profile_ID");
            DropColumn("dbo.Songs", "Profile_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Profile_ID", c => c.Int());
            AddColumn("dbo.Instruments", "Profile_ID", c => c.Int());
            DropForeignKey("dbo.SongProfiles", "Profile_ID", "dbo.Profiles");
            DropForeignKey("dbo.SongProfiles", "Song_ID", "dbo.Songs");
            DropForeignKey("dbo.ProfileInstruments", "Instrument_ID", "dbo.Instruments");
            DropForeignKey("dbo.ProfileInstruments", "Profile_ID", "dbo.Profiles");
            DropIndex("dbo.SongProfiles", new[] { "Profile_ID" });
            DropIndex("dbo.SongProfiles", new[] { "Song_ID" });
            DropIndex("dbo.ProfileInstruments", new[] { "Instrument_ID" });
            DropIndex("dbo.ProfileInstruments", new[] { "Profile_ID" });
            DropTable("dbo.SongProfiles");
            DropTable("dbo.ProfileInstruments");
            CreateIndex("dbo.Songs", "Profile_ID");
            CreateIndex("dbo.Instruments", "Profile_ID");
            AddForeignKey("dbo.Songs", "Profile_ID", "dbo.Profiles", "ID");
            AddForeignKey("dbo.Instruments", "Profile_ID", "dbo.Profiles", "ID");
        }
    }
}
