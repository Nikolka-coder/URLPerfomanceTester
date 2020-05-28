using System.Net;

namespace URLPerformanceTester.ViewModels
{
    public class RequestTestViewModel
    {
        public string Url { get; set; }
        public int Time { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}