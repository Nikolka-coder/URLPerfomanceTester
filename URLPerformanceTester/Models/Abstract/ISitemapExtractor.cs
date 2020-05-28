using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
  public   interface ISitemapExtractor
    {
        IEnumerable<string> TryExtract(string url);
    }
}
