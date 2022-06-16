namespace DBoperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Type = c.String(),
                        Price = c.String(),
                        Currency = c.String(),
                        NumberOfPages = c.Int(nullable: false),
                        isLeased = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Leases",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        LeaseStart = c.DateTime(nullable: false),
                        LeaseEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookID, t.UserID });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Leases");
            DropTable("dbo.Books");
        }
    }
}
