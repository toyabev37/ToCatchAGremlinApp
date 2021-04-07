namespace ToCatchAGremlin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gremlins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OfficerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Officers", t => t.OfficerID, cascadeDelete: true)
                .Index(t => t.OfficerID);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gremlins", "OfficerID", "dbo.Officers");
            DropIndex("dbo.Gremlins", new[] { "OfficerID" });
            DropTable("dbo.Officers");
            DropTable("dbo.Gremlins");
        }
    }
}
