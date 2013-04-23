namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestHistories",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        StatusID = c.Int(nullable: false),
                        SubmitterID = c.Guid(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SubmitterID, cascadeDelete: true)
                .Index(t => t.StatusID)
                .Index(t => t.SubmitterID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RequestHistories", new[] { "SubmitterID" });
            DropIndex("dbo.RequestHistories", new[] { "StatusID" });
            DropForeignKey("dbo.RequestHistories", "SubmitterID", "dbo.Users");
            DropForeignKey("dbo.RequestHistories", "StatusID", "dbo.Status");
            DropTable("dbo.RequestHistories");
        }
    }
}
