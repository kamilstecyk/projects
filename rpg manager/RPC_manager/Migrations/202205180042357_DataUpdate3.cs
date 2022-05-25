namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUpdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dragons", "Cave_CaveID", "dbo.Caves");
            DropForeignKey("dbo.Ents", "Coppice_CoppiceID", "dbo.Coppices");
            DropForeignKey("dbo.Mags", "Tower_TowerID", "dbo.Towers");
            DropForeignKey("dbo.Caves", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Coppices", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Towers", "UserElements_UserElementsID", "dbo.UserElements");
            DropIndex("dbo.Caves", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.Dragons", new[] { "Cave_CaveID" });
            DropIndex("dbo.Coppices", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.Ents", new[] { "Coppice_CoppiceID" });
            DropIndex("dbo.Mags", new[] { "Tower_TowerID" });
            DropIndex("dbo.Towers", new[] { "UserElements_UserElementsID" });
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharactersID = c.Int(nullable: false, identity: true),
                        UserElements_UserElementsID = c.Int(),
                    })
                .PrimaryKey(t => t.CharactersID)
                .ForeignKey("dbo.UserElements", t => t.UserElements_UserElementsID)
                .Index(t => t.UserElements_UserElementsID);
            
            CreateTable(
                "dbo.Inanimates",
                c => new
                    {
                        InanimateID = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        UserElements_UserElementsID = c.Int(),
                    })
                .PrimaryKey(t => t.InanimateID)
                .ForeignKey("dbo.UserElements", t => t.UserElements_UserElementsID)
                .Index(t => t.UserElements_UserElementsID);
            
            AddColumn("dbo.Caves", "depth", c => c.Int(nullable: false));
            AddColumn("dbo.Caves", "Inanimate_InanimateID", c => c.Int());
            AddColumn("dbo.Dragons", "Characters_CharactersID", c => c.Int());
            AddColumn("dbo.Coppices", "Inanimate_InanimateID", c => c.Int());
            AddColumn("dbo.Ents", "Characters_CharactersID", c => c.Int());
            AddColumn("dbo.Mags", "Characters_CharactersID", c => c.Int());
            AddColumn("dbo.Towers", "Inanimate_InanimateID", c => c.Int());
            CreateIndex("dbo.Caves", "Inanimate_InanimateID");
            CreateIndex("dbo.Coppices", "Inanimate_InanimateID");
            CreateIndex("dbo.Dragons", "Characters_CharactersID");
            CreateIndex("dbo.Ents", "Characters_CharactersID");
            CreateIndex("dbo.Mags", "Characters_CharactersID");
            CreateIndex("dbo.Towers", "Inanimate_InanimateID");
            CreateIndex("dbo.UserElements", "UserID", unique: true);
            AddForeignKey("dbo.Dragons", "Characters_CharactersID", "dbo.Characters", "CharactersID");
            AddForeignKey("dbo.Ents", "Characters_CharactersID", "dbo.Characters", "CharactersID");
            AddForeignKey("dbo.Mags", "Characters_CharactersID", "dbo.Characters", "CharactersID");
            AddForeignKey("dbo.Caves", "Inanimate_InanimateID", "dbo.Inanimates", "InanimateID");
            AddForeignKey("dbo.Coppices", "Inanimate_InanimateID", "dbo.Inanimates", "InanimateID");
            AddForeignKey("dbo.Towers", "Inanimate_InanimateID", "dbo.Inanimates", "InanimateID");
            DropColumn("dbo.Caves", "Area");
            DropColumn("dbo.Caves", "UserElements_UserElementsID");
            DropColumn("dbo.Dragons", "Cave_CaveID");
            DropColumn("dbo.Coppices", "UserElements_UserElementsID");
            DropColumn("dbo.Ents", "Coppice_CoppiceID");
            DropColumn("dbo.Mags", "Tower_TowerID");
            DropColumn("dbo.Towers", "UserElements_UserElementsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Towers", "UserElements_UserElementsID", c => c.Int());
            AddColumn("dbo.Mags", "Tower_TowerID", c => c.Int());
            AddColumn("dbo.Ents", "Coppice_CoppiceID", c => c.Int());
            AddColumn("dbo.Coppices", "UserElements_UserElementsID", c => c.Int());
            AddColumn("dbo.Dragons", "Cave_CaveID", c => c.Int());
            AddColumn("dbo.Caves", "UserElements_UserElementsID", c => c.Int());
            AddColumn("dbo.Caves", "Area", c => c.Int(nullable: false));
            DropForeignKey("dbo.Inanimates", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Towers", "Inanimate_InanimateID", "dbo.Inanimates");
            DropForeignKey("dbo.Coppices", "Inanimate_InanimateID", "dbo.Inanimates");
            DropForeignKey("dbo.Caves", "Inanimate_InanimateID", "dbo.Inanimates");
            DropForeignKey("dbo.Characters", "UserElements_UserElementsID", "dbo.UserElements");
            DropForeignKey("dbo.Mags", "Characters_CharactersID", "dbo.Characters");
            DropForeignKey("dbo.Ents", "Characters_CharactersID", "dbo.Characters");
            DropForeignKey("dbo.Dragons", "Characters_CharactersID", "dbo.Characters");
            DropIndex("dbo.Inanimates", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.Characters", new[] { "UserElements_UserElementsID" });
            DropIndex("dbo.UserElements", new[] { "UserID" });
            DropIndex("dbo.Towers", new[] { "Inanimate_InanimateID" });
            DropIndex("dbo.Mags", new[] { "Characters_CharactersID" });
            DropIndex("dbo.Ents", new[] { "Characters_CharactersID" });
            DropIndex("dbo.Dragons", new[] { "Characters_CharactersID" });
            DropIndex("dbo.Coppices", new[] { "Inanimate_InanimateID" });
            DropIndex("dbo.Caves", new[] { "Inanimate_InanimateID" });
            DropColumn("dbo.Towers", "Inanimate_InanimateID");
            DropColumn("dbo.Mags", "Characters_CharactersID");
            DropColumn("dbo.Ents", "Characters_CharactersID");
            DropColumn("dbo.Coppices", "Inanimate_InanimateID");
            DropColumn("dbo.Dragons", "Characters_CharactersID");
            DropColumn("dbo.Caves", "Inanimate_InanimateID");
            DropColumn("dbo.Caves", "depth");
            DropTable("dbo.Inanimates");
            DropTable("dbo.Characters");
            CreateIndex("dbo.Towers", "UserElements_UserElementsID");
            CreateIndex("dbo.Mags", "Tower_TowerID");
            CreateIndex("dbo.Ents", "Coppice_CoppiceID");
            CreateIndex("dbo.Coppices", "UserElements_UserElementsID");
            CreateIndex("dbo.Dragons", "Cave_CaveID");
            CreateIndex("dbo.Caves", "UserElements_UserElementsID");
            AddForeignKey("dbo.Towers", "UserElements_UserElementsID", "dbo.UserElements", "UserElementsID");
            AddForeignKey("dbo.Coppices", "UserElements_UserElementsID", "dbo.UserElements", "UserElementsID");
            AddForeignKey("dbo.Caves", "UserElements_UserElementsID", "dbo.UserElements", "UserElementsID");
            AddForeignKey("dbo.Mags", "Tower_TowerID", "dbo.Towers", "TowerID");
            AddForeignKey("dbo.Ents", "Coppice_CoppiceID", "dbo.Coppices", "CoppiceID");
            AddForeignKey("dbo.Dragons", "Cave_CaveID", "dbo.Caves", "CaveID");
        }
    }
}
