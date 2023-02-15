namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecategoryid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caves", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Ents", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Mags", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Coppices", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Towers", "CategoryID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Towers", "CategoryID");
            DropColumn("dbo.Coppices", "CategoryID");
            DropColumn("dbo.Mags", "CategoryID");
            DropColumn("dbo.Ents", "CategoryID");
            DropColumn("dbo.Caves", "CategoryID");
        }
    }
}
