using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using URLPerformanceTester.Models.Concrete;

namespace URLPerformanceTester.Tests.Models
{

    public class ReqSpeed
    {
        [Fact]
        public void Speed()
        {
            while (true)
            {
                var res = new HtmlLinksExtractor(new HttpWebRequestCreator()).Extract(new Uri("http://dataart.ua/"), new Uri("http://dataart.ua/"));
            }

        }
    }
}
