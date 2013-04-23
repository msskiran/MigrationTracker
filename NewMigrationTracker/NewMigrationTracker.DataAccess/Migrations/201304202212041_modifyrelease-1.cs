namespace NewMigrationTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class modifyrelease1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "RequestID", "dbo.Releases");
            DropIndex("dbo.Requests", new[] { "RequestID" });
            //      RenameColumn(table: "dbo.Requests", name: "RequestID", newName: "ReleaseID");
            DropPrimaryKey("dbo.Requests", new[] { "RequestID" });
            AddPrimaryKey("dbo.Requests", "RequestID");
            AddForeignKey("dbo.Requests", "ReleaseID", "dbo.Releases", "ReleaseID", cascadeDelete: true);
            CreateIndex("dbo.Requests", "ReleaseID");
        }

        public override void Down()
        {
            DropIndex("dbo.Requests", new[] { "ReleaseID" });
            DropForeignKey("dbo.Requests", "ReleaseID", "dbo.Releases");
            DropPrimaryKey("dbo.Requests", new[] { "RequestID" });
            AddPrimaryKey("dbo.Requests", "RequestID");
            RenameColumn(table: "dbo.Requests", name: "ReleaseID", newName: "RequestID");
            CreateIndex("dbo.Requests", "RequestID");
            AddForeignKey("dbo.Requests", "RequestID", "dbo.Releases", "ReleaseID");
        }
    }
}
