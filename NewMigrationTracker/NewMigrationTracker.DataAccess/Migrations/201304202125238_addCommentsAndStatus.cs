namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentsAndStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentDescription = c.String(maxLength: 1000),
                        RequestID = c.Int(nullable: false),
                        CommenterID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Users", t => t.CommenterID, cascadeDelete: true)
                .Index(t => t.CommenterID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "CommenterID" });
            DropForeignKey("dbo.Comments", "CommenterID", "dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Status");
        }
    }
}
