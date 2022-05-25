namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueCategories : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Characters", "Level", unique: true);
            CreateIndex("dbo.Characters", "Power", unique: true);
            CreateIndex("dbo.Inanimates", "Area", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Inanimates", new[] { "Area" });
            DropIndex("dbo.Characters", new[] { "Power" });
            DropIndex("dbo.Characters", new[] { "Level" });
        }
    }
}
