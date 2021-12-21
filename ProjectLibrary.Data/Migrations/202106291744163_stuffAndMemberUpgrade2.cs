namespace ProjectLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffAndMemberUpgrade2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stuffs", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stuffs", "Role", c => c.String());
        }
    }
}
