namespace DBoperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateKeyOFLeases : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Leases");
            AddColumn("dbo.Leases", "LeaseID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Leases", "LeaseID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Leases");
            DropColumn("dbo.Leases", "LeaseID");
            AddPrimaryKey("dbo.Leases", new[] { "BookID", "UserID" });
        }
    }
}
