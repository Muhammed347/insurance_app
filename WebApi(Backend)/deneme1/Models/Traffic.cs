using System.ComponentModel.DataAnnotations;

namespace deneme1.Models
{
    public class Traffic : Policy
    {
        
        public int TrafficId { get; set; }
        public string? PlateCityCode { get; set; }
        public string? PlateCode { get; set; }
    }
}
