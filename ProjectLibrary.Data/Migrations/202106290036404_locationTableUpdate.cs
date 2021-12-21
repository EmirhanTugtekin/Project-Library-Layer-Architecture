namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "BookID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "BookID", c => c.Int(nullable: false));
        }
    }
}
