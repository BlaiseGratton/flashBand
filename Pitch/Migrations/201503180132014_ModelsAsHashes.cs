namespace Pitch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsAsHashes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Players", newName: "UserHashes");
            DropColumn("dbo.Instruments", "playerIDs");
            DropColumn("dbo.Songs", "playerIDs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "playerIDs", c => c.String());
            AddColumn("dbo.Instruments", "playerIDs", c => c.String());
            RenameTable(name: "dbo.UserHashes", newName: "Players");
        }
    }
}
