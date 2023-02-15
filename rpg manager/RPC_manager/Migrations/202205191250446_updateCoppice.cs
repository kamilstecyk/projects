namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCoppice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coppices", "NumberOfTrees", c => c.Int(nullable: false));
            DropColumn("dbo.Coppices", "Area");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coppices", "Area", c => c.Int(nullable: false));
            DropColumn("dbo.Coppices", "NumberOfTrees");
        }
    }
}
