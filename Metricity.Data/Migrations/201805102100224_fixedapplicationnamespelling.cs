namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedapplicationnamespelling : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Metrics", "ApplicationName", c => c.String());
            DropColumn("dbo.Metrics", "AppliactionName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Metrics", "AppliactionName", c => c.String());
            DropColumn("dbo.Metrics", "ApplicationName");
        }
    }
}
