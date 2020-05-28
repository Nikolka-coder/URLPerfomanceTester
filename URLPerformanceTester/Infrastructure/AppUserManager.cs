using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Infrastructure
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store, IdentityFactoryOptions<AppUserManager> options) : base(store)
        {
            UserValidator = new UserValidator<AppUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };
        }
    }
}