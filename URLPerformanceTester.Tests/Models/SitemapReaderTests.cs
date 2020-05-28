using System;
using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Concrete;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class SitemapReaderTests
    {
        [Fact]
        public void ReadSitemapTest()
        {
            //arrange
            var uri = new Uri("http://mathus.ru/sitemap.xml");
            var reader = new SitemapReader();
            IEnumerable<Uri> urls;
            //act
            var result = reader.TryReadSitemap(uri, out urls);
            //assert
            Assert.True(urls.Count() != 0);
            Assert.True(result);
        }

    }
}
