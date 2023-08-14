using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace deneme6.Model
{
    public class Police
    {
        public int PoliceId { get; set; }

        public int PoliceNum { get; set; }

        public string? PoliceType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double? Prim { get; set; }
    }
}

[JsonSerializable(typeof(List<Police>))]
internal sealed partial class PoliceContext : JsonSerializerContext
{

}