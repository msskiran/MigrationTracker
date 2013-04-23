namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyAppln : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReleaseApplications", "Release_ReleaseID", "dbo.Releases");
            DropForeignKey("dbo.ReleaseApplications", "Application_ApplicationID", "dbo.Applications");
            DropIndex("dbo.ReleaseApplications", new[] { "Release_ReleaseID" });
            DropIndex("dbo.ReleaseApplications", new[] { "Application_ApplicationID" });
            AddForeignKey("dbo.Applications", "ApplicationID", "dbo.Releases", "ReleaseID");
            CreateIndex("dbo.Applications", "ApplicationID");
            DropTable("dbo.ReleaseApplications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReleaseApplications",
                c => new
                    {
                        Release_ReleaseID = c.Int(nullable: false),
                        Application_ApplicationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Release_ReleaseID, t.Application_ApplicationID });
            
            DropIndex("dbo.Applications", new[] { "ApplicationID" });
            DropForeignKey("dbo.Applications", "ApplicationID", "dbo.Releases");
            CreateIndex("dbo.ReleaseApplications", "Application_ApplicationID");
            CreateIndex("dbo.ReleaseApplications", "Release_ReleaseID");
            AddForeignKey("dbo.ReleaseApplications", "Application_ApplicationID", "dbo.Applications", "ApplicationID", cascadeDelete: true);
            AddForeignKey("dbo.ReleaseApplications", "Release_ReleaseID", "dbo.Releases", "ReleaseID", cascadeDelete: true);
        }
    }
}
