namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Metrics",
                c => new
                    {
                        MetricId = c.Int(nullable: false, identity: true),
                        AppliactionName = c.String(),
                        MethodName = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MetricId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Metrics");
        }
    }
}
