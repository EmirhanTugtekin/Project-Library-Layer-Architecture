namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 30, unicode: false),
                        AuthorSurname = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(maxLength: 30, unicode: false),
                        PublishYear = c.Short(nullable: false),
                        Publisher = c.String(maxLength: 30, unicode: false),
                        Available = c.Int(nullable: false),
                        Language = c.String(maxLength: 30, unicode: false),
                        Stock = c.Int(nullable: false),
                        AvailableStock = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Locations", t => t.LocationID)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        BorrowingID = c.Int(nullable: false, identity: true),
                        DateOfBorrowed = c.DateTime(nullable: false),
                        DateOfReturn = c.DateTime(nullable: false),
                        ActualDateOfReturn = c.DateTime(nullable: false),
                        BookID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        StuffID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowingID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .ForeignKey("dbo.Stuffs", t => t.StuffID)
                .Index(t => t.BookID)
                .Index(t => t.MemberID)
                .Index(t => t.StuffID);
            
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        FineID = c.Int(nullable: false, identity: true),
                        DateOfStart = c.DateTime(nullable: false),
                        DateOfEnd = c.DateTime(nullable: false),
                        Cash = c.Double(nullable: false),
                        BookName = c.String(maxLength: 30, unicode: false),
                        MemberID = c.Int(nullable: false),
                        BorrrowingID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Borrowing_BorrowingID = c.Int(),
                    })
                .PrimaryKey(t => t.FineID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Borrowings", t => t.Borrowing_BorrowingID)
                .ForeignKey("dbo.Members", t => t.MemberID)
                .Index(t => t.MemberID)
                .Index(t => t.BookID)
                .Index(t => t.Borrowing_BorrowingID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MemberSurname = c.String(),
                        NickName = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Sex = c.String(),
                        Job = c.String(),
                        DateOfMembership = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "dbo.Stuffs",
                c => new
                    {
                        StuffID = c.Int(nullable: false, identity: true),
                        StuffName = c.String(),
                        StuffSurname = c.String(),
                        NickName = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Sex = c.String(),
                        DateOfHiring = c.DateTime(nullable: false),
                        Role = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Photo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StuffID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        floor = c.Short(nullable: false),
                        section = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        BookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.LibrarySituations",
                c => new
                    {
                        LibrarySituationID = c.Int(nullable: false, identity: true),
                        NumberOfStuff = c.Int(nullable: false),
                        NumberOfMember = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LibrarySituationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Borrowings", "StuffID", "dbo.Stuffs");
            DropForeignKey("dbo.Fines", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Borrowings", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Fines", "Borrowing_BorrowingID", "dbo.Borrowings");
            DropForeignKey("dbo.Fines", "BookID", "dbo.Books");
            DropForeignKey("dbo.Borrowings", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "BookID" });
            DropIndex("dbo.Fines", new[] { "Borrowing_BorrowingID" });
            DropIndex("dbo.Fines", new[] { "BookID" });
            DropIndex("dbo.Fines", new[] { "MemberID" });
            DropIndex("dbo.Borrowings", new[] { "StuffID" });
            DropIndex("dbo.Borrowings", new[] { "MemberID" });
            DropIndex("dbo.Borrowings", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "LocationID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropTable("dbo.LibrarySituations");
            DropTable("dbo.Comments");
            DropTable("dbo.Locations");
            DropTable("dbo.Categories");
            DropTable("dbo.Stuffs");
            DropTable("dbo.Members");
            DropTable("dbo.Fines");
            DropTable("dbo.Borrowings");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
