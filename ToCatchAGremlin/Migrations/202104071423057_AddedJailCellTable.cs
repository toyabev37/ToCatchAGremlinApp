namespace ToCatchAGremlin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJailCellTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JailCells",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CellNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Gremlins", "JailCellID", c => c.Int(nullable: false));
            CreateIndex("dbo.Gremlins", "JailCellID");
            AddForeignKey("dbo.Gremlins", "JailCellID", "dbo.JailCells", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gremlins", "JailCellID", "dbo.JailCells");
            DropIndex("dbo.Gremlins", new[] { "JailCellID" });
            DropColumn("dbo.Gremlins", "JailCellID");
            DropTable("dbo.JailCells");
        }
    }
}
