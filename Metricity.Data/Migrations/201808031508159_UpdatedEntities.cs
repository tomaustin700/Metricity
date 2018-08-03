namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "Occurred", c => c.DateTime(nullable: false));
            DropColumn("dbo.Metrics", "APIKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Metrics", "APIKey", c => c.Guid(nullable: false));
            DropColumn("dbo.Metrics", "Occurred");
        }
    }
}
