namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamDatas",
                c => new
                    {
                        TeamID = c.Int(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        TaskID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamID, t.ApplicationID, t.ProjectID, t.TaskID })
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.ApplicationID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.ApplicationID)
                .Index(t => t.ProjectID)
                .Index(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TeamDatas", new[] { "TaskID" });
            DropIndex("dbo.TeamDatas", new[] { "ProjectID" });
            DropIndex("dbo.TeamDatas", new[] { "ApplicationID" });
            DropIndex("dbo.TeamDatas", new[] { "TeamID" });
            DropForeignKey("dbo.TeamDatas", "TaskID", "dbo.Tasks");
            DropForeignKey("dbo.TeamDatas", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.TeamDatas", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.TeamDatas", "TeamID", "dbo.Teams");
            DropTable("dbo.TeamDatas");
        }
    }
}
