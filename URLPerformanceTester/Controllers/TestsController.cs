using System.Linq;
using System.Web.Mvc;
using System;
using System.Web;
using Microsoft.AspNet.Identity;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.ViewModels;
using URLPerformanceTester.Models.Entities;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly AppUserManager _userManager;
        private AppUser _currentUser;
        private AppUser CurrentUser => _currentUser ?? (_currentUser = _userManager.FindById(User.Identity.GetUserId()));
        private readonly IBackgroundTaskManager<ISitemapBackgroundTester> _backgroundTaskManager;

        public TestsController(AppUserManager userManager,
            IBackgroundTaskManager<ISitemapBackgroundTester> backgroundTaskManager)
        {
            _userManager = userManager;
            _backgroundTaskManager = backgroundTaskManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View("Index", model: CurrentUser.Id);
        }
        public ActionResult OverviewList(string id)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            var result =
                CurrentUser.SitemapTests.OrderByDescending(st => st.CreationTime)
                    .Select(st => new RequestTestsSetOverviewViewModel
                    {
                        Id = st.Id,
                        CreationTime = st.CreationTime,
                        RequestUrl = st.SitemapUrl,
                        UrLsCount = st.UrLsCount,
                        UrLsTested = st.UrlTests.Count
                    }).ToList();
            return PartialView("OverviewList", result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new RequestTestsSetViewModel());
        }

        [HttpPost]
        public ActionResult Create(RequestTestsSetViewModel model)
        {
            if (ModelState.IsValid)
            {

                var test = new RequestTestSet()
                {
                    SitemapUrl = model.Uri.ToString(),
                    CreationTime = DateTime.UtcNow
                };
                CurrentUser.SitemapTests.Add(test);
                _userManager.Update(CurrentUser);
                _backgroundTaskManager.AddTask(t => t.Perform(new Uri(test.SitemapUrl), test.Id));
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var test = CurrentUser.SitemapTests.Find(t => t.Id == id);
            if (test == null) return new HttpNotFoundResult();
            var model = new RequestTestsSetDetailsViewModel()
            {
                CreationTime = TimeZone.CurrentTimeZone.ToLocalTime(test.CreationTime),
                RequestUrl = test.SitemapUrl,
                MaxTime = test.MaxTime,
                MinTime = test.MinTime,
                ModeTime = test.ModeTime,
                UrLsCount = test.UrLsCount,
                UrLsTested = test.UrlTests.Count,
                UrlTestResults = test.UrlTests.Select(t => new RequestTestViewModel()
                {
                    Time = t.Time,
                    StatusCode = t.StatusCode,
                    Url = t.Url,
                }).OrderByDescending(t => t.Time).ToList()
            };
            return View(model);
        }
    }
}