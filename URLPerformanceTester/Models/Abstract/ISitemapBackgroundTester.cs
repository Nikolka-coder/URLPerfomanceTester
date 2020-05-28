using System;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapBackgroundTester
    {
        void Perform(Uri uri, int sitemapTestId);
    }
}