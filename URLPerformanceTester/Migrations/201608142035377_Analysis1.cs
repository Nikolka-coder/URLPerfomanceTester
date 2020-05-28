namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Analysis1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestTestSets", "MinTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "ModeTime", c => c.Int(nullable: false));
            DropColumn("dbo.RequestTestSets", "Analysis_MinTime");
            DropColumn("dbo.RequestTestSets", "Analysis_MaxTime");
            DropColumn("dbo.RequestTestSets", "Analysis_ModeTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestTestSets", "Analysis_ModeTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "Analysis_MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "Analysis_MinTime", c => c.Int(nullable: false));
            DropColumn("dbo.RequestTestSets", "ModeTime");
            DropColumn("dbo.RequestTestSets", "MaxTime");
            DropColumn("dbo.RequestTestSets", "MinTime");
        }
    }
}
