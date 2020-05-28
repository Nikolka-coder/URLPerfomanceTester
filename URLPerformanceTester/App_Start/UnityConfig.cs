using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System;
using System.Web;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Concrete;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer() => Container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserStore<AppUser>, UserStore<AppUser>>(
                new InjectionConstructor(typeof(AppDbContext)));
            container.RegisterType<IHttpWebRequestCreator, HttpWebRequestCreator>();
            container.RegisterType<IGenericRepository<RequestTestSet>, GenericRepository<AppDbContext, RequestTestSet>>();
            container.RegisterType<ISitemapReader, SitemapReader>();
            container.RegisterType<IUrlTester, UrlTester>();
            container.RegisterType<IHtmlLinksExtractor, HtmlLinksExtractor>();
            container.RegisterType<ISitemapBuilder, SitemapBuiler>();
            container.RegisterType<ISitemapDeterminant, SitemapDeterminant>();
            container.RegisterType<ISitemapBackgroundTester, SitemapBackgroundTester>();
            container.RegisterType<IApproximativeModeAlgorithm, ApproximativeModeAlgorithm>();
            container
                .RegisterType
                <IBackgroundTaskManager<ISitemapBackgroundTester>, BackgroundTaskManager<ISitemapBackgroundTester>>();
        }
    }
}