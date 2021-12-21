namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fineUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Fines", new[] { "Borrowing_BorrowingID" });
            RenameColumn(table: "dbo.Fines", name: "Borrowing_BorrowingID", newName: "BorrowingID");
            AlterColumn("dbo.Fines", "BorrowingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Fines", "BorrowingID");
            DropColumn("dbo.Fines", "BookName");
            DropColumn("dbo.Fines", "BorrrowingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fines", "BorrrowingID", c => c.Int(nullable: false));
            AddColumn("dbo.Fines", "BookName", c => c.String(maxLength: 30, unicode: false));
            DropIndex("dbo.Fines", new[] { "BorrowingID" });
            AlterColumn("dbo.Fines", "BorrowingID", c => c.Int());
            RenameColumn(table: "dbo.Fines", name: "BorrowingID", newName: "Borrowing_BorrowingID");
            CreateIndex("dbo.Fines", "Borrowing_BorrowingID");
        }
    }
}
