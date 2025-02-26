namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutDate");
        }
    }
}
