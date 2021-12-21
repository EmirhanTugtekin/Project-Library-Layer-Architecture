namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowingUpdate5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Borrowings", "ActualDateOfReturn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Borrowings", "ActualDateOfReturn", c => c.DateTime(nullable: false));
        }
    }
}
