using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Model
{
    public class Dask
    {
        public int DaskId { get; set; }
        public string Adress { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        public int ProductId { get; set; }

        public int PersonId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public double Prim { get; set;} 

    }
}
