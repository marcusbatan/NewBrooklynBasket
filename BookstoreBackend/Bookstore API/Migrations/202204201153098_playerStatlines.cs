namespace Bookstore_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerStatlines : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Position = c.String(),
                        FavPlayer = c.String(),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        GamesPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player_StatlineModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegisterDate = c.String(),
                        PlayerModel_Id = c.Int(),
                        StatlineModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayerModels", t => t.PlayerModel_Id)
                .ForeignKey("dbo.StatlineModels", t => t.StatlineModel_Id)
                .Index(t => t.PlayerModel_Id)
                .Index(t => t.StatlineModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player_StatlineModel", "StatlineModel_Id", "dbo.StatlineModels");
            DropForeignKey("dbo.Player_StatlineModel", "PlayerModel_Id", "dbo.PlayerModels");
            DropIndex("dbo.Player_StatlineModel", new[] { "StatlineModel_Id" });
            DropIndex("dbo.Player_StatlineModel", new[] { "PlayerModel_Id" });
            DropTable("dbo.Player_StatlineModel");
            DropTable("dbo.PlayerModels");
        }
    }
}
