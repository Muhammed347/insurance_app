using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Model
{
    public class PolicyDask
    {
        public int DaskId { get; set; }
        public string District { get; set; }
        public string City { get; set; }

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
