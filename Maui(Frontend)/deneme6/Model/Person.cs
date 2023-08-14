using deneme6.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace deneme6.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string KimlikNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}

[JsonSerializable(typeof(List<Person>))]
internal sealed partial class PersonContext : JsonSerializerContext
{

}