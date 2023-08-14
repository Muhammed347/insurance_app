using System.ComponentModel.DataAnnotations;

namespace deneme1.Models
{
    //this class contains informations about policy company
    public class Product
    {
        
        public int ProductId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
