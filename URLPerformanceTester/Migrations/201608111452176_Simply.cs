namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Simply : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SitemapTests", newName: "RequestTestSets");
            DropForeignKey("dbo.URLTests", "SitemapTest_Id", "dbo.SitemapTests");
            DropIndex("dbo.URLTests", new[] { "SitemapTest_Id" });
            CreateTable(
                "dbo.RequestTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Time = c.Int(nullable: false),
                        StatusCode = c.Int(nullable: false),
                        RequestTestSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestTestSets", t => t.RequestTestSet_Id)
                .Index(t => t.RequestTestSet_Id);
            
            DropTable("dbo.URLTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.URLTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Time = c.Int(nullable: false),
                        StatusCode = c.Int(nullable: false),
                        SitemapTest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RequestTests", "RequestTestSet_Id", "dbo.RequestTestSets");
            DropIndex("dbo.RequestTests", new[] { "RequestTestSet_Id" });
            DropTable("dbo.RequestTests");
            CreateIndex("dbo.URLTests", "SitemapTest_Id");
            AddForeignKey("dbo.URLTests", "SitemapTest_Id", "dbo.SitemapTests", "Id");
            RenameTable(name: "dbo.RequestTestSets", newName: "SitemapTests");
        }
    }
}
