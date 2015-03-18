namespace Pitch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthInitialization : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "instrumentIDs");
            DropColumn("dbo.Players", "songIDs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "songIDs", c => c.String());
            AddColumn("dbo.Players", "instrumentIDs", c => c.String());
        }
    }
}
