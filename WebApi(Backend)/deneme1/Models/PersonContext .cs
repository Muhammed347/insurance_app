using Microsoft.EntityFrameworkCore;

namespace deneme1.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Dask> Dasks { get; set; } = null!;

        public DbSet<Traffic> Traffics { get; set; } = null!;

        public DbSet<Kasko> Kaskos { get; set; } = null!;
    }
}
