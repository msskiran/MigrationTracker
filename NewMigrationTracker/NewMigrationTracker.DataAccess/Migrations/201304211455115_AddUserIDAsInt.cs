namespace NewMigrationTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserIDAsInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "CreatedBy", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserRoles", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "CommenterID", c => c.Int(nullable: false));
            AddColumn("dbo.RequestHistories", "UpdatedBy", c => c.Int(nullable: false));
            //DropPrimaryKey("dbo.Users", new[] { "UserIdentity" });
            AddPrimaryKey("dbo.Users", "UserID");
            DropPrimaryKey("dbo.UserRoles", new[] { "RoleID", "ApplicationID" });
            AddPrimaryKey("dbo.UserRoles", new[] { "UserID", "RoleID", "ApplicationID" });
            AddForeignKey("dbo.Requests", "CreatedBy", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "CommenterID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.RequestHistories", "UpdatedBy", "dbo.Users", "UserID", cascadeDelete: true);
            CreateIndex("dbo.Requests", "CreatedBy");
            CreateIndex("dbo.UserRoles", "UserID");
            CreateIndex("dbo.Comments", "CommenterID");
            CreateIndex("dbo.RequestHistories", "UpdatedBy");
            //  DropColumn("dbo.Users", "UserIdentity");
        }

        public override void Down()
        {
            //AddColumn("dbo.Users", "UserIdentity", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.RequestHistories", new[] { "UpdatedBy" });
            DropIndex("dbo.Comments", new[] { "CommenterID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.Requests", new[] { "CreatedBy" });
            DropForeignKey("dbo.RequestHistories", "UpdatedBy", "dbo.Users");
            DropForeignKey("dbo.Comments", "CommenterID", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.Requests", "CreatedBy", "dbo.Users");
            DropPrimaryKey("dbo.UserRoles", new[] { "UserID", "RoleID", "ApplicationID" });
            AddPrimaryKey("dbo.UserRoles", new[] { "RoleID", "ApplicationID" });
            DropPrimaryKey("dbo.Users", new[] { "UserID" });
            //AddPrimaryKey("dbo.Users", "UserIdentity");
            DropColumn("dbo.RequestHistories", "UpdatedBy");
            DropColumn("dbo.Comments", "CommenterID");
            DropColumn("dbo.UserRoles", "UserID");
            DropColumn("dbo.Users", "UserID");
            DropColumn("dbo.Requests", "CreatedBy");
        }
    }
}
