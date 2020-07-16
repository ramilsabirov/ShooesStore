namespace ShooesStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadRoles : DbMigration
    {
        public override void Up()
        {
            Sql("insert dbo.Roles values ('admin'),('user')");
        }
        
        public override void Down()
        {
        }
    }
}
