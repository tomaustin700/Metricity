namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHandledException : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandledExceptions",
                c => new
                    {
                        HandledExceptionId = c.Int(nullable: false, identity: true),
                        InnerException = c.String(),
                        ExceptionType = c.String(),
                        Occurred = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HandledExceptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HandledExceptions");
        }
    }
}
