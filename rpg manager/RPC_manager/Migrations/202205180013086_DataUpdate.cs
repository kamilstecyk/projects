namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dragons", "Species", c => c.Int(nullable: false));
            AddColumn("dbo.Mags", "Circle", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mags", "Circle");
            DropColumn("dbo.Dragons", "Species");
        }
    }
}
