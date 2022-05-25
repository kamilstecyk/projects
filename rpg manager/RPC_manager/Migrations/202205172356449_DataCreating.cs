namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataCreating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caves",
                c => new
                    {
                        CaveID = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        UserElements_UserElementsID = c.Int(),
                    })
                .PrimaryKey(t => t.CaveID)
                .ForeignKey("dbo.UserElements", t => t.UserElements_UserElementsID)
                .Index(t => t.UserElements_UserElementsID);
            
            CreateTable(
                "dbo.Dragons",
                c => new
                    {
                        DragonID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WingSpan = c.Int(nullable: false),
                        Cave_CaveID = c.Int(),
                    })
                .PrimaryKey(t => t.DragonID)
                .ForeignKey("dbo.Caves", t => t.Cave_CaveID)
                .Index(t => t.Cave_CaveID);
            
            CreateTable(
                "dbo.Coppices",
                c => new
                    {
                        CoppiceID = c.Int(nullable: false, identity: true),
                        area = c.Int(nullable: false),
                        UserElements_UserElementsID = c.Int(),
                    })
                .PrimaryKey(t => t.CoppiceID)
                .ForeignKey("dbo.UserElements", t => t.UserElements_UserElementsID)
                .Index(t => t.UserElements_UserElementsID);
            
            CreateTable(
                "dbo.Ents",
                c => new
                    {
                        EntID = c.Int(nullable: false, identity: true),
                        numberOfJars = c.Int(nullable: false),
                        name = c.String(),
                        Coppice_CoppiceID = c.Int(),
                    })
                .PrimaryKey(t => t.EntID)
                .ForeignKey("dbo.Coppices", t => t.Coppice_CoppiceID)
                .Index(t => t.Coppice_CoppiceID);
            
            CreateTable(
                "dbo.Mags",
                c => new
                    {
                        MagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LevelOfPower = c.Int(nullable: false),
                        Tower_TowerID = c.Int(),
                    })
                .PrimaryKey(t => t.MagID)
                .ForeignKey("dbo.Towers", t => t.Tower_TowerID)
                .Index(t => t.Tower_TowerID);
            
            CreateTable(
                "dbo.Towers",
                c => new
                    {
                        TowerID = c.Int(nullable: false, identity: true),
                        Height = c.Int(nullable: false),
                        material = c.String(),
                        UserElements_UserElementsID = c.Int(),
                    })
                .PrimaryKey(t => t.TowerID)
                .ForeignKey("dbo.UserElements", t => t.UserElements_UserElementsID)
                .Index(t => t.UserElements_UserElementsID);
            
            CreateTable(
                "dbo.UserElements",
                c => new
                    {
                        UserElementsID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserElementsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Towers", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Coppices", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Caves", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Mags", "Tower_TowerID", "dbo.Towers");
            DropForeignKey("dbo.Ents", "Coppice_CoppiceID", "dbo.Coppices");
            DropForeignKey("dbo.Dragons", "Cave_CaveID", "dbo.Caves");
            DropIndex("dbo.Towers", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.Mags", new[] { "Tower_TowerID" });
            DropIndex("dbo.Ents", new[] { "Coppice_CoppiceID" });
            DropIndex("dbo.Coppices", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.Dragons", new[] { "Cave_CaveID" });
            DropIndex("dbo.Caves", new[] { "UserElements_UserElementsID" });
            DropTable("dbo.UserElements");
            DropTable("dbo.Towers");
            DropTable("dbo.Mags");
            DropTable("dbo.Ents");
            DropTable("dbo.Coppices");
            DropTable("dbo.Dragons");
            DropTable("dbo.Caves");
        }
    }
}
