namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAPIKeyToMetricEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "APIKey", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Metrics", "APIKey");
        }
    }
}
