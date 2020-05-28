namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Simly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SitemapTests", "MinTime", c => c.Int(nullable: false));
            AddColumn("dbo.SitemapTests", "MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.SitemapTests", "UrLsCount", c => c.Int(nullable: false));
            AddColumn("dbo.URLTests", "Time", c => c.Int(nullable: false));
            DropColumn("dbo.SitemapTests", "TestsPerURL");
            DropColumn("dbo.SitemapTests", "URLsCountToTest");
            DropColumn("dbo.URLTests", "MinTime");
            DropColumn("dbo.URLTests", "MaxTime");
            DropColumn("dbo.URLTests", "AvgTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.URLTests", "AvgTime", c => c.Int(nullable: false));
            AddColumn("dbo.URLTests", "MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.URLTests", "MinTime", c => c.Int(nullable: false));
            AddColumn("dbo.SitemapTests", "URLsCountToTest", c => c.Int(nullable: false));
            AddColumn("dbo.SitemapTests", "TestsPerURL", c => c.Int(nullable: false));
            DropColumn("dbo.URLTests", "Time");
            DropColumn("dbo.SitemapTests", "UrLsCount");
            DropColumn("dbo.SitemapTests", "MaxTime");
            DropColumn("dbo.SitemapTests", "MinTime");
        }
    }
}
