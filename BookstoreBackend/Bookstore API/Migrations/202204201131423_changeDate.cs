namespace Bookstore_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StatlineModels", "RegLineDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StatlineModels", "RegLineDate", c => c.DateTime(nullable: false));
        }
    }
}
