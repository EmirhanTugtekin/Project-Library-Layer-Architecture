namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowingUpdate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowings", "ActualDateOfReturn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Borrowings", "ActualDateOfReturn");
        }
    }
}
