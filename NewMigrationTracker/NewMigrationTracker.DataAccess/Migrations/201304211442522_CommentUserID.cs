namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUserID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "CommenterID", "dbo.Users");
            DropForeignKey("dbo.RequestHistories", "UpdatedBy", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "CreatedBy" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "CommenterID" });
            DropIndex("dbo.RequestHistories", new[] { "UpdatedBy" });
            AddColumn("dbo.Users", "UserIdentity", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Users", new[] { "UserID" });
            AddPrimaryKey("dbo.Users", "UserIdentity");
            DropPrimaryKey("dbo.UserRoles", new[] { "UserID", "RoleID", "ApplicationID" });
            AddPrimaryKey("dbo.UserRoles", new[] { "RoleID", "ApplicationID" });
            DropColumn("dbo.Requests", "CreatedBy");
            DropColumn("dbo.Users", "UserID");
            DropColumn("dbo.UserRoles", "UserID");
            DropColumn("dbo.Comments", "CommenterID");
            DropColumn("dbo.RequestHistories", "UpdatedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestHistories", "UpdatedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.Comments", "CommenterID", c => c.Guid(nullable: false));
            AddColumn("dbo.UserRoles", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Requests", "CreatedBy", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.UserRoles", new[] { "RoleID", "ApplicationID" });
            AddPrimaryKey("dbo.UserRoles", new[] { "UserID", "RoleID", "ApplicationID" });
            DropPrimaryKey("dbo.Users", new[] { "UserIdentity" });
            AddPrimaryKey("dbo.Users", "UserID");
            DropColumn("dbo.Users", "UserIdentity");
            CreateIndex("dbo.RequestHistories", "UpdatedBy");
            CreateIndex("dbo.Comments", "CommenterID");
            CreateIndex("dbo.UserRoles", "UserID");
            CreateIndex("dbo.Requests", "CreatedBy");
            AddForeignKey("dbo.RequestHistories", "UpdatedBy", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "CommenterID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.Requests", "CreatedBy", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
