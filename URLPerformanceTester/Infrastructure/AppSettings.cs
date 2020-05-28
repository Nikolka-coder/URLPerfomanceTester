using System;
using System.Web.Configuration;

namespace URLPerformanceTester.Infrastructure
{
    public static class AppSettings
    {
        static public string RequestUserAgent =>
        WebConfigurationManager.AppSettings["RequestUserAgent"];

        static public string RequestAcceptLanguage =>
        WebConfigurationManager.AppSettings["RequestAcceptLanguage"];

        static public int BackgroudTesterDataPortionSize =>
       Convert.ToInt16(WebConfigurationManager.AppSettings["BackgroudTesterDataPortionSize"]);
    }
}