using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using URLPerformanceTester.Models.Concrete;

namespace URLPerformanceTester.Infrastructure
{
    public class AccessibleURLAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var uri = value as Uri;
            if (uri == null) return false;
            try
            {
                var urlAttr = new UrlAttribute();
                if (!urlAttr.IsValid(uri.ToString()))
                {
                    ErrorMessage = urlAttr.ErrorMessage;
                    return false;
                }
                try
                {
                    var request = new HttpWebRequestCreator().Create(uri);
                    using (var response = (HttpWebResponse)request.GetResponse())
                    {
                        return (response.StatusCode == HttpStatusCode.OK);
                    }
                }
                catch (WebException e)
                {
                    ErrorMessage = e.Message;
                    return false;
                }
            }
            catch (UriFormatException e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }
    }
}