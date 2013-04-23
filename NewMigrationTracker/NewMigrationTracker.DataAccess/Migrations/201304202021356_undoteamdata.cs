namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class undoteamdata : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TeamDatas", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.TeamDatas", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.TeamDatas", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.TeamDatas", "TaskID", "dbo.Tasks");
            DropIndex("dbo.TeamDatas", new[] { "TeamID" });
            DropIndex("dbo.TeamDatas", new[] { "ApplicationID" });
            DropIndex("dbo.TeamDatas", new[] { "ProjectID" });
            DropIndex("dbo.TeamDatas", new[] { "TaskID" });
            AddColumn("dbo.Applications", "TeamID", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ApplicationID", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "ProjectID", c => c.Int(nullable: false));
            AddForeignKey("dbo.Applications", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ApplicationID", "dbo.Applications", "ApplicationID", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            CreateIndex("dbo.Applications", "TeamID");
            CreateIndex("dbo.Projects", "ApplicationID");
            CreateIndex("dbo.Tasks", "ProjectID");
            DropTable("dbo.TeamDatas");
        }
        
        public override void Down()
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
                .PrimaryKey(t => new { t.TeamID, t.ApplicationID, t.ProjectID, t.TaskID });
            
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            DropIndex("dbo.Projects", new[] { "ApplicationID" });
            DropIndex("dbo.Applications", new[] { "TeamID" });
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ApplicationID", "dbo.Applications");
            DropForeignKey("dbo.Applications", "TeamID", "dbo.Teams");
            DropColumn("dbo.Tasks", "ProjectID");
            DropColumn("dbo.Projects", "ApplicationID");
            DropColumn("dbo.Applications", "TeamID");
            CreateIndex("dbo.TeamDatas", "TaskID");
            CreateIndex("dbo.TeamDatas", "ProjectID");
            CreateIndex("dbo.TeamDatas", "ApplicationID");
            CreateIndex("dbo.TeamDatas", "TeamID");
            AddForeignKey("dbo.TeamDatas", "TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
            AddForeignKey("dbo.TeamDatas", "ProjectID", "dbo.Projects", "ProjectID", cascadeDelete: true);
            AddForeignKey("dbo.TeamDatas", "ApplicationID", "dbo.Applications", "ApplicationID", cascadeDelete: true);
            AddForeignKey("dbo.TeamDatas", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
        }
    }
}
