namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrowingUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrowings", "SituationOfBorrowing", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Borrowings", "SituationOfBorrowing");
        }
    }
}
