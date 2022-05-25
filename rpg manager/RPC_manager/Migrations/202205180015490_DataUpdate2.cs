namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ents", "Species", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ents", "Species");
        }
    }
}
