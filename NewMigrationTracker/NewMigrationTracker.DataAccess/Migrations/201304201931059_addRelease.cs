namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Releases",
                c => new
                    {
                        ReleaseID = c.Int(nullable: false, identity: true),
                        ReleaseName = c.String(maxLength: 100),
                        ApplicationID = c.Int(nullable: false),
                        BusinessLabel = c.String(maxLength: 250),
                        SourceControlLabel = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ReleaseID);
            
            CreateTable(
                "dbo.ReleaseApplications",
                c => new
                    {
                        Release_ReleaseID = c.Int(nullable: false),
                        Application_ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Release_ReleaseID, t.Application_ApplicationID })
                .ForeignKey("dbo.Releases", t => t.Release_ReleaseID, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.Application_ApplicationID, cascadeDelete: true)
                .Index(t => t.Release_ReleaseID)
                .Index(t => t.Application_ApplicationID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ReleaseApplications", new[] { "Application_ApplicationID" });
            DropIndex("dbo.ReleaseApplications", new[] { "Release_ReleaseID" });
            DropForeignKey("dbo.ReleaseApplications", "Application_ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.ReleaseApplications", "Release_ReleaseID", "dbo.Releases");
            DropTable("dbo.ReleaseApplications");
            DropTable("dbo.Releases");
        }
    }
}
