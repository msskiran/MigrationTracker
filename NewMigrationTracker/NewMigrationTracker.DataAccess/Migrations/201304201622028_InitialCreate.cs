namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TeamID);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        ApplicationName = c.String(nullable: false, maxLength: 100),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationID)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 100),
                        ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .Index(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 250),
                        TaskDescription = c.String(maxLength: 500),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.RoleType",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 100),
                        UserDomain = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "ApplicationID" });
            DropIndex("dbo.Applications", new[] { "TeamID" });
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Applications", "TeamID", "dbo.Teams");
            DropTable("dbo.Users");
            DropTable("dbo.RoleType");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Applications");
            DropTable("dbo.Teams");
        }
    }
}
