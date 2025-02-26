namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salestable_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        SalesName = c.String(),
                        SalesCount = c.Int(nullable: false),
                        SalesRevenue = c.Int(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sales");
        }
    }
}
