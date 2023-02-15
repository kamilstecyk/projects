namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        login = c.String(maxLength: 450),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.userID)
                .Index(t => t.login, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "login" });
            DropTable("dbo.Users");
        }
    }
}
