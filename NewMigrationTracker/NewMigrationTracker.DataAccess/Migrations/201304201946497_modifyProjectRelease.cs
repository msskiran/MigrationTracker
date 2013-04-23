namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyProjectRelease : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "ApplicationID", "dbo.Releases");
            DropIndex("dbo.Applications", new[] { "ApplicationID" });
            CreateTable(
                "dbo.ReleaseProjects",
                c => new
                    {
                        Release_ReleaseID = c.Int(nullable: false),
                        Project_ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Release_ReleaseID, t.Project_ProjectID })
                .ForeignKey("dbo.Releases", t => t.Release_ReleaseID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID, cascadeDelete: true)
                .Index(t => t.Release_ReleaseID)
                .Index(t => t.Project_ProjectID);
            
            AddColumn("dbo.Releases", "ProjectId", c => c.Int(nullable: false));
            DropColumn("dbo.Releases", "ApplicationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Releases", "ApplicationID", c => c.Int(nullable: false));
            DropIndex("dbo.ReleaseProjects", new[] { "Project_ProjectID" });
            DropIndex("dbo.ReleaseProjects", new[] { "Release_ReleaseID" });
            DropForeignKey("dbo.ReleaseProjects", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ReleaseProjects", "Release_ReleaseID", "dbo.Releases");
            DropColumn("dbo.Releases", "ProjectId");
            DropTable("dbo.ReleaseProjects");
            CreateIndex("dbo.Applications", "ApplicationID");
            AddForeignKey("dbo.Applications", "ApplicationID", "dbo.Releases", "ReleaseID");
        }
    }
}
