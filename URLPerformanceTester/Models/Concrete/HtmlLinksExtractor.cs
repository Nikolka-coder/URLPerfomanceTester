using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class HtmlLinksExtractor : IHtmlLinksExtractor
    {
        IHttpWebRequestCreator _requestCreator;
        public HtmlLinksExtractor(IHttpWebRequestCreator requestCreator)
        {
            _requestCreator = requestCreator;
        }
        public IEnumerable<Uri> Extract(Uri uri, Uri baseUri)
        {
            var request = _requestCreator.Create(uri);         
            try
            {
                using (var response = request.GetResponse())
                {
                    if (response.ContentType.Contains("text/html"))
                    {                    
                        var doc = new HtmlDocument();
                        doc.Load(response.GetResponseStream());
                        return doc.DocumentNode.SelectNodes("//a")
                            .Select(a => a.GetAttributeValue("href", null))
                            .Where(l => l != null)
                            .Select(l => new Uri(l, UriKind.RelativeOrAbsolute))
                            .Where(u => isLocal(u, baseUri) && !isHash(u))
                            .Select(u => u.IsAbsoluteUri ? u : new Uri(baseUri, u));
                    }
                    return null;
                }
            }
            catch (WebException)
            {
                return null;
            }
        }
        private bool isLocal(Uri uri, Uri baseUri) => baseUri.IsBaseOf(uri);
        private bool isHash(Uri uri) => uri.ToString().Contains('#');
    }
}