// <auto-generated />
namespace NewMigrationTracker.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class AddUserIDAsInt : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddUserIDAsInt));
        
        string IMigrationMetadata.Id
        {
            get { return "201304211455115_AddUserIDAsInt"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
