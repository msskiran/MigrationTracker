namespace NewMigrationTracker.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Requests", name: "SubmitterID", newName: "CreatedBy");
            RenameColumn(table: "dbo.RequestHistories", name: "SubmitterID", newName: "UpdatedBy");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.RequestHistories", name: "UpdatedBy", newName: "SubmitterID");
            RenameColumn(table: "dbo.Requests", name: "CreatedBy", newName: "SubmitterID");
        }
    }
}
