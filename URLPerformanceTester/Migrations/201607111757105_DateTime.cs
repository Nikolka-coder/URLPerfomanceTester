namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SitemapTests", "CreationTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SitemapTests", "CreationTime", c => c.DateTime(nullable: false));
        }
    }
}
