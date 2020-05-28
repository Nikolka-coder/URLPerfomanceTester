using System;
using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface ISitemapDeterminant
    {
        IEnumerable<Uri> DeterminateSitemap(Uri uri);
    }
}
