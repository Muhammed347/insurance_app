using System.ComponentModel.DataAnnotations;

namespace deneme1.Models
{
    //automobile insurance
    public class Kasko : Policy
    {
        
        public int KaskoId { get; set; }

        public string? VehicleModel { get; set; }
        public string? VehicleBrand { get; set; }

    }
}
