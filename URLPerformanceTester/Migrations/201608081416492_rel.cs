namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Rel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.URLTestResults", newName: "URLTests");
            DropForeignKey("dbo.URLTestTasks", "Owner_Id", "dbo.SitemapTests");
            DropIndex("dbo.URLTestTasks", new[] { "Owner_Id" });
            AddColumn("dbo.SitemapTests", "TestsPerURL", c => c.Int(nullable: false));
            AddColumn("dbo.SitemapTests", "URLsCountToTest", c => c.Int(nullable: false));
            DropTable("dbo.URLTestTasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.URLTestTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SitemapURL = c.String(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.SitemapTests", "URLsCountToTest");
            DropColumn("dbo.SitemapTests", "TestsPerURL");
            CreateIndex("dbo.URLTestTasks", "Owner_Id");
            AddForeignKey("dbo.URLTestTasks", "Owner_Id", "dbo.SitemapTests", "Id");
            RenameTable(name: "dbo.URLTests", newName: "URLTestResults");
        }
    }
}
