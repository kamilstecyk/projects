namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "level", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "power", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "power");
            DropColumn("dbo.Characters", "level");
        }
    }
}
