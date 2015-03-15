namespace Pitch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_CSVs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instruments", "playerIDs", c => c.String());
            AddColumn("dbo.Players", "instrumentIDs", c => c.String());
            AddColumn("dbo.Players", "songIDs", c => c.String());
            AddColumn("dbo.Songs", "playerIDs", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "playerIDs");
            DropColumn("dbo.Players", "songIDs");
            DropColumn("dbo.Players", "instrumentIDs");
            DropColumn("dbo.Instruments", "playerIDs");
        }
    }
}
