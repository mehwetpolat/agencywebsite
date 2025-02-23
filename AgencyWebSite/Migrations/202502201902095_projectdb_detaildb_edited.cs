namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectdb_detaildb_edited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectDetails", "ProjectDetailTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectDetails", "ProjectDetailTitle");
        }
    }
}
