namespace DBoperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 450));
            AlterColumn("dbo.Users", "Login", c => c.String(maxLength: 450));
            CreateIndex("dbo.Books", "Title", unique: true);
            CreateIndex("dbo.Users", "Login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.Books", new[] { "Title" });
            AlterColumn("dbo.Users", "Login", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
