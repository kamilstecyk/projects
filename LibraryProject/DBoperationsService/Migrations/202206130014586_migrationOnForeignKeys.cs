namespace DBoperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationOnForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Leases", "BookID");
            CreateIndex("dbo.Leases", "UserID");
            AddForeignKey("dbo.Leases", "BookID", "dbo.Books", "BookID", cascadeDelete: true);
            AddForeignKey("dbo.Leases", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leases", "UserID", "dbo.Users");
            DropForeignKey("dbo.Leases", "BookID", "dbo.Books");
            DropIndex("dbo.Leases", new[] { "UserID" });
            DropIndex("dbo.Leases", new[] { "BookID" });
        }
    }
}
