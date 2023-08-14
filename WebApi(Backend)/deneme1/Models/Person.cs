using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace deneme1.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        
        public string? IdentificationNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
    }
}
