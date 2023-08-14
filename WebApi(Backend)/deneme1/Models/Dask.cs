using System.ComponentModel.DataAnnotations;

namespace deneme1.Models
{
    //Dask(in Turkish):natural disaster insurance agency
    public class Dask : Policy
    {
        
        public int DaskId { get; set; }
        public string? Adress { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
    }
}
