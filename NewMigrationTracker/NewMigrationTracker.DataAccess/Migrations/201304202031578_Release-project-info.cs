namespace NewMigrationTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Releaseprojectinfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ProjectID", "dbo.Releases");
            DropIndex("dbo.Projects", new[] { "ProjectID" });
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

        }

        public override void Down()
        {
            DropIndex("dbo.ReleaseProjects", new[] { "Project_ProjectID" });
            DropIndex("dbo.ReleaseProjects", new[] { "Release_ReleaseID" });
            DropForeignKey("dbo.ReleaseProjects", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ReleaseProjects", "Release_ReleaseID", "dbo.Releases");
            DropTable("dbo.ReleaseProjects");
            CreateIndex("dbo.Projects", "ProjectID");
            AddForeignKey("dbo.Projects", "ProjectID", "dbo.Releases", "ReleaseID");
        }
    }
}
