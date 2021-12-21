namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Available", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Available", c => c.Int(nullable: false));
        }
    }
}
