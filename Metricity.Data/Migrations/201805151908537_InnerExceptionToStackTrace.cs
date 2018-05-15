namespace Metricity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InnerExceptionToStackTrace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HandledExceptions", "StackTrace", c => c.String());
            DropColumn("dbo.HandledExceptions", "InnerException");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HandledExceptions", "InnerException", c => c.String());
            DropColumn("dbo.HandledExceptions", "StackTrace");
        }
    }
}
