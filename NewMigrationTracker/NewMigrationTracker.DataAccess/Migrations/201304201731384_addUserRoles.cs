namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        RoleID = c.Int(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.RoleID, t.ApplicationID })
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.RoleType", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID)
                .Index(t => t.ApplicationID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserRoles", new[] { "ApplicationID" });
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropForeignKey("dbo.UserRoles", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.RoleType");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropTable("dbo.UserRoles");
        }
    }
}
