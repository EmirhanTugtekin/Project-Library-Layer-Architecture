namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffAndMemberUpgrade3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stuffs", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stuffs", "Photo", c => c.DateTime(nullable: false));
        }
    }
}
