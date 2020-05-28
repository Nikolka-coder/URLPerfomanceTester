using System;
using System.Collections.Generic;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapDeterminant : ISitemapDeterminant
    {
        private readonly ISitemapReader _sitemapReader;
        private readonly ISitemapBuilder _sitemapBuilder;
        public SitemapDeterminant(ISitemapReader sitemapReader, ISitemapBuilder sitemapBuilder)
        {
            _sitemapReader = sitemapReader;
            _sitemapBuilder = sitemapBuilder;
        }

        public IEnumerable<Uri> DeterminateSitemap(Uri uri)
        {
            var sitemapUrl = new Uri(uri, "/sitemap.xml");
            IEnumerable<Uri> urls = null;
            if (_sitemapReader.TryReadSitemap(sitemapUrl, out urls)) return urls;
            else
                return _sitemapBuilder.BuildSitemap(uri);
        }
    }
}