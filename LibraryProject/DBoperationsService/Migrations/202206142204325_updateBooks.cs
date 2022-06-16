namespace DBoperationsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBooks : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Price", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Price", c => c.String());
        }
    }
}
