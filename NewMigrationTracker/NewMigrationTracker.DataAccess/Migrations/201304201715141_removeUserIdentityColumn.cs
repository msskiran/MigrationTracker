namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserIdentityColumn : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users", new[] { "UserIdentity" });
            AddPrimaryKey("dbo.Users", "UserID");
            DropColumn("dbo.Users", "UserIdentity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserIdentity", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users", new[] { "UserID" });
            AddPrimaryKey("dbo.Users", "UserIdentity");
        }
    }
}
