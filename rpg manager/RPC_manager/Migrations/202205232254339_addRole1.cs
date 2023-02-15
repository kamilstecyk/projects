namespace RPC_manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRole1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "role");
        }
    }
}
