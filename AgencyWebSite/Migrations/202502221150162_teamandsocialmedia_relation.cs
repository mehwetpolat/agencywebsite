namespace AgencyWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamandsocialmedia_relation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaId = c.Int(nullable: false, identity: true),
                        TwitterUrl = c.String(),
                        FacebookUrl = c.String(),
                        LinkedinUrl = c.String(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SocialMediaId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMedias", "TeamId", "dbo.Teams");
            DropIndex("dbo.SocialMedias", new[] { "TeamId" });
            DropTable("dbo.SocialMedias");
        }
    }
}
