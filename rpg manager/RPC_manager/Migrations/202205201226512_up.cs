namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dragons", "addedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ents", "addedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Mags", "addedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mags", "addedDate");
            DropColumn("dbo.Ents", "addedDate");
            DropColumn("dbo.Dragons", "addedDate");
        }
    }
}
