using System;
using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IHtmlLinksExtractor
    {
        IEnumerable<Uri> Extract(Uri uri, Uri baseUri);
    }
}
