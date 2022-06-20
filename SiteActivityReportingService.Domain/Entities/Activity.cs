using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteActivityReportingService.Domain.Entities
{
    public class Activity
    {
        public int id { get; set; }
        public string key { get; set; }
        public int value { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
