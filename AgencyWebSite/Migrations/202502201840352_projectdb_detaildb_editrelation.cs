namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projectdb_detaildb_editrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectDetails", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectDetails", "ProjectId");
            AddForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            DropColumn("dbo.ProjectDetails", "ProjectDetailName");
            DropColumn("dbo.ProjectDetails", "ProjectDetailTitle");
            DropColumn("dbo.ProjectDetails", "ProjectDetailImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectDetails", "ProjectDetailImageUrl", c => c.String());
            AddColumn("dbo.ProjectDetails", "ProjectDetailTitle", c => c.String());
            AddColumn("dbo.ProjectDetails", "ProjectDetailName", c => c.String());
            DropForeignKey("dbo.ProjectDetails", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectDetails", new[] { "ProjectId" });
            DropColumn("dbo.ProjectDetails", "ProjectId");
        }
    }
}
