using System;
using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public  interface ISitemapBuilder
    {
        IEnumerable<Uri> BuildSitemap(Uri sitemapUri);
    }
}
