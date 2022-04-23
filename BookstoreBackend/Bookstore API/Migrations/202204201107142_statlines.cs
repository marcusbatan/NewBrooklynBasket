namespace Bookstore_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statlines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatlineModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Points = c.Int(nullable: false),
                        Rebounds = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        Steals = c.Int(nullable: false),
                        Blocks = c.Int(nullable: false),
                        FGA = c.Int(nullable: false),
                        FGM = c.Int(nullable: false),
                        ThreePTA = c.Int(nullable: false),
                        ThreePTM = c.Int(nullable: false),
                        FTA = c.Int(nullable: false),
                        FTM = c.Int(nullable: false),
                        RegLineDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StatlineModels");
        }
    }
}
