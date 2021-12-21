namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 30, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
