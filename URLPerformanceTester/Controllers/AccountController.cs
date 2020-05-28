using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AppUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;
        public AccountController(IAuthenticationManager authManager, AppUserManager userManager)
        {
            _userManager = userManager;
            _authenticationManager = authManager;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl)
        {
            AppUser user = null;
            var cookieId = CookieStoredUserId;
            if (CookieStoredUserId != null)
            {
                user = await UserManager.FindByIdAsync(cookieId);
            }
            if (user == null)
            {
                user = new AppUser();
                user.UserName = user.Id;
                var r = await UserManager.CreateAsync(user);
                CookieStoredUserId = user.Id;
            }
            var ident = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignOut();
            AuthManager.SignIn(new AuthenticationProperties {IsPersistent = false}, ident);
            return new RedirectResult(returnUrl);
        }

        private string CookieStoredUserId
        {
            get
            {
                return Request.Cookies[UserIdCookieName]?.Value;
            }
            set
            {
                var cookie = new HttpCookie(UserIdCookieName)
                {
                    Value = value,
                    Expires = DateTime.Now.AddYears(1)
                };
                Response.Cookies.Add(cookie);
            }
        }
        private const string UserIdCookieName = "UserId";
        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
    }
}