using System;
using System.Net;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IHttpWebRequestCreator
    {
        HttpWebRequest Create(Uri uri);
    }
}
