namespace URLPerformanceTester.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Analysis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestTestSets", "Analysis_MinTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "Analysis_MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "Analysis_ModeTime", c => c.Int(nullable: false));
            DropColumn("dbo.RequestTestSets", "MinTime");
            DropColumn("dbo.RequestTestSets", "MaxTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestTestSets", "MaxTime", c => c.Int(nullable: false));
            AddColumn("dbo.RequestTestSets", "MinTime", c => c.Int(nullable: false));
            DropColumn("dbo.RequestTestSets", "Analysis_ModeTime");
            DropColumn("dbo.RequestTestSets", "Analysis_MaxTime");
            DropColumn("dbo.RequestTestSets", "Analysis_MinTime");
        }
    }
}
