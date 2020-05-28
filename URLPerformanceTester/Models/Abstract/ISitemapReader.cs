using System;
using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapReader
    {
        bool TryReadSitemap(Uri uri, out IEnumerable<Uri> sitemapUrls);
    }
}
