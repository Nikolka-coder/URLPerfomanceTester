using System;
using System.Net;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class HttpWebRequestCreator : IHttpWebRequestCreator
    {
        public HttpWebRequest Create(Uri uri)
        {
            var request = WebRequest.CreateHttp(uri);
            request.AllowAutoRedirect = true;
            request.UserAgent = AppSettings.RequestUserAgent;
            request.Headers.Add("Accept-Language", AppSettings.RequestAcceptLanguage);
            request.CookieContainer = new CookieContainer();
            request.Proxy = null;          
            return request;
        }
    }
}