using System;
using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Abstract;


namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapBuiler : ISitemapBuilder
    {
        private readonly IHtmlLinksExtractor _linksExtractor;
        public SitemapBuiler(IHtmlLinksExtractor linksExtractor)
        {
            _linksExtractor = linksExtractor;
        }
        public IEnumerable<Uri> BuildSitemap(Uri baseUri)
        {
            var urlsToTest = new List<Uri>() { baseUri };
            var result = new HashSet<Uri>() { baseUri };
            while (urlsToTest.Any())
            {
                var current = urlsToTest.LastOrDefault();
                urlsToTest.Remove(current);
                var uris = _linksExtractor.Extract(current, baseUri);                   
                if (uris == null) continue;
                var uniqUris = uris.Where(u => !result.Contains(u));
                urlsToTest.AddRange(uniqUris.Where(u=>!u.IsFile));
                foreach (var u in uniqUris) result.Add(u);
            }
            return result;
        }
    }
}