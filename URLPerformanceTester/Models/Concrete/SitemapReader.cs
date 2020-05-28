using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapReader : ISitemapReader
    {
        private string RootName(XDocument document) => document.Root?.Name.LocalName;
        private IEnumerable<string> ExtractUrLs(XDocument sitemap)
            => sitemap.Descendants().Where(e => e.Name.LocalName == "loc").Select(e => e.Value);

        public bool TryReadSitemap(Uri sitemapUrl, out IEnumerable<Uri> sitemapUrls)
        {
            try
            {
                var doc = XDocument.Load(sitemapUrl.ToString());
                var rootname = RootName(doc);
                if (rootname == "urlset")
                {
                    sitemapUrls = ExtractUrLs(doc).Select(l=>new Uri(l));
                    return true;
                }
                else if (rootname == "sitemapindex")
                {
                    var result = new List<string>();
                    var doc_t = ExtractUrLs(doc);
                    foreach (var url in doc_t)
                    {
                        var ext = ExtractUrLs(XDocument.Load(url));
                        result.AddRange(ext);
                    }
                    sitemapUrls = result.Select(l => new Uri(l));
                    return true;
                }
            }
            catch (WebException)
            {
                sitemapUrls = null;
                return false;
            }
            catch (XmlException)
            {
                sitemapUrls = null;
                return false;
            }
            sitemapUrls = null;
            return false;
        }
    }
}