namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminimageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "ImageUrl");
        }
    }
}
