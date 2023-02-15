namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqEl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Dragons", new[] { "Name" });
            DropIndex("dbo.Ents", new[] { "Name" });
            DropIndex("dbo.Mags", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "login" });
            AlterColumn("dbo.Dragons", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Ents", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Mags", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "login", c => c.String(maxLength: 30));
            CreateIndex("dbo.Dragons", "Name", unique: true);
            CreateIndex("dbo.Ents", "Name", unique: true);
            CreateIndex("dbo.Mags", "Name", unique: true);
            CreateIndex("dbo.Users", "login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "login" });
            DropIndex("dbo.Mags", new[] { "Name" });
            DropIndex("dbo.Ents", new[] { "Name" });
            DropIndex("dbo.Dragons", new[] { "Name" });
            AlterColumn("dbo.Users", "login", c => c.String(maxLength: 450));
            AlterColumn("dbo.Mags", "Name", c => c.String());
            AlterColumn("dbo.Ents", "Name", c => c.String());
            AlterColumn("dbo.Dragons", "Name", c => c.String());
            CreateIndex("dbo.Users", "login", unique: true);
            CreateIndex("dbo.Mags", "Name", unique: true);
            CreateIndex("dbo.Ents", "Name", unique: true);
            CreateIndex("dbo.Dragons", "Name", unique: true);
        }
    }
}
