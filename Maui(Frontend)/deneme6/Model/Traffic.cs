using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Model
{
    public class Traffic
    {
        public int TrafficId { get; set; }
        public string PlateCityCode { get; set; }
        public string PlateCode { get; set; }

        public int ProductId { get; set; }

        public int PersonId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public double Prim { get; set; }

    }
}
