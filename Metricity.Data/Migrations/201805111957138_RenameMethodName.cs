namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameMethodName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "MetricName", c => c.String());
            DropColumn("dbo.Metrics", "MethodName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Metrics", "MethodName", c => c.String());
            DropColumn("dbo.Metrics", "MetricName");
        }
    }
}
