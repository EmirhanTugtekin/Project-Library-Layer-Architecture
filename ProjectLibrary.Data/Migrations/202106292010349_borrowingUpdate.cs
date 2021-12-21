namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowingUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Borrowings", "ActualDateOfReturn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrowings", "ActualDateOfReturn", c => c.DateTime(nullable: false));
        }
    }
}
