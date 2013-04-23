namespace NewMigrationTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CommentRequestRelation : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.Comments", "RequestID", "dbo.Requests", "RequestID", cascadeDelete: false);
            CreateIndex("dbo.Comments", "RequestID");
        }

        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "RequestID" });
            DropForeignKey("dbo.Comments", "RequestID", "dbo.Requests");
        }
    }
}
