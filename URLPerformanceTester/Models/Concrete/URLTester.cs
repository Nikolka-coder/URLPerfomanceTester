using System;
using System.Diagnostics;
using System.Net;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class UrlTester : IUrlTester
    {
        IHttpWebRequestCreator _requestCreator;
        CookieContainer _cookieContainer;
        public UrlTester(IHttpWebRequestCreator requestCreator)
        {
            _requestCreator = requestCreator;
            _cookieContainer = new CookieContainer();
        }
        public RequestTest Test(Uri uri)
        {
            var test = new RequestTest() { Url = uri.ToString() };
            var sw = new Stopwatch();
            var request = _requestCreator.Create(uri);
            request.CookieContainer = _cookieContainer;
            try
            {
                sw.Start();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    test.Time = (int)sw.ElapsedMilliseconds;
                    test.StatusCode = response.StatusCode;
                }
                return test;
            }
            catch (WebException ex)
            {
                test.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
                return test;
            }
        }
    }
}