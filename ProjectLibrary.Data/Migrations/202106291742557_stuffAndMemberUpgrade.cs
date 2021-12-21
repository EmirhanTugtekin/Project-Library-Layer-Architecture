namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffAndMemberUpgrade : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "PhoneNumber");
            DropColumn("dbo.Members", "Sex");
            DropColumn("dbo.Members", "Job");
            DropColumn("dbo.Stuffs", "PhoneNumber");
            DropColumn("dbo.Stuffs", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stuffs", "Sex", c => c.String());
            AddColumn("dbo.Stuffs", "PhoneNumber", c => c.String());
            AddColumn("dbo.Members", "Job", c => c.String());
            AddColumn("dbo.Members", "Sex", c => c.String());
            AddColumn("dbo.Members", "PhoneNumber", c => c.String());
        }
    }
}
