namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequestAndModifyRelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        StatusID = c.Int(nullable: false),
                        SubmitterID = c.Guid(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ReleaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SubmitterID, cascadeDelete: true)
                .ForeignKey("dbo.Releases", t => t.RequestID)
                .Index(t => t.StatusID)
                .Index(t => t.SubmitterID)
                .Index(t => t.RequestID);
            
            DropColumn("dbo.Releases", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Releases", "ProjectId", c => c.Int(nullable: false));
            DropIndex("dbo.Requests", new[] { "RequestID" });
            DropIndex("dbo.Requests", new[] { "SubmitterID" });
            DropIndex("dbo.Requests", new[] { "StatusID" });
            DropForeignKey("dbo.Requests", "RequestID", "dbo.Releases");
            DropForeignKey("dbo.Requests", "SubmitterID", "dbo.Users");
            DropForeignKey("dbo.Requests", "StatusID", "dbo.Status");
            DropTable("dbo.Requests");
        }
    }
}
