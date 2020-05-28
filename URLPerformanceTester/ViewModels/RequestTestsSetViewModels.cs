using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using URLPerformanceTester.Infrastructure;

namespace URLPerformanceTester.ViewModels
{
    public class RequestTestsSetViewModel
    {
        
        public string RawUrl { get; set; }

        [AccessibleURL]
        public Uri Uri
        {
            get
            {
                try
                {
                    return new UriBuilder(RawUrl).Uri;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

    public class RequestTestsSetOverviewViewModel
    {
        public int Id { get; set; }
        public string RequestUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public int UrLsCount { get; set; }
        public int UrLsTested { get; set; }
        public bool IsCompleted => UrLsCount > 0 && UrLsCount == UrLsTested;
    }

    public class RequestTestsSetDetailsViewModel
    {
        public string RequestUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int ModeTime { get; set; }
        public int UrLsCount { get; set; }
        public int UrLsTested { get; set; }
        public List<RequestTestViewModel> UrlTestResults { get; set; }
    }
}