using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Model
{
    public class PolicyTraffic
    {
        public int TrafficId { get; set; }
        public string PlateCityCode { get; set; }
        public string PlateCode { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public double Prim { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public bool IsExpired
        {
            get { return ExpiryDate < DateTime.Now; }
        }
    }
}
