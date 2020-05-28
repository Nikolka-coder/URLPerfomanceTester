using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        static AppDbContext()
        {
            Database.SetInitializer(new IdentityDbInit());
        }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<RequestTestSet> SitemapTests { get; set; }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AppDbContext context)
        {
            // initial configuration will go here
        }
    }
}