namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationTableUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "section", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "section", c => c.Short(nullable: false));
        }
    }
}
