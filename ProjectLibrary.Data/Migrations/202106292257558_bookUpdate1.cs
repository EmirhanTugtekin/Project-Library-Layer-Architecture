namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Stock");
            DropColumn("dbo.Books", "AvailableStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AvailableStock", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Stock", c => c.Int(nullable: false));
        }
    }
}
