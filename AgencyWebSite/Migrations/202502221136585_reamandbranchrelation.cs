namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reamandbranchrelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "BranchId");
            AddForeignKey("dbo.Teams", "BranchId", "dbo.Branches", "BranchId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "BranchId", "dbo.Branches");
            DropIndex("dbo.Teams", new[] { "BranchId" });
            DropColumn("dbo.Teams", "BranchId");
        }
    }
}
