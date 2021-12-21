namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowingUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Borrowings", "DateOfBorrowed", c => c.String());
            AlterColumn("dbo.Borrowings", "DateOfReturn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Borrowings", "DateOfReturn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Borrowings", "DateOfBorrowed", c => c.DateTime(nullable: false));
        }
    }
}
