using System.Net;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLPerformanceTester.Models.Entities
{
    public class RequestTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public int Time { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}