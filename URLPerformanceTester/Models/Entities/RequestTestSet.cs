using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLPerformanceTester.Models.Entities
{
    public class RequestTestSet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SitemapUrl { get; set; }
        public DateTime CreationTime { get; set; }
        public int MinTime { get; set; }
        public int MaxTime { get; set; }
        public int ModeTime { get; set; }
        public virtual List<RequestTest> UrlTests { get; set; }
        public int UrLsCount { get; set; }
    }
}