using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace deneme6.Services
{
    public class PoliceService
    {
        HttpClient httpClient;
        public PoliceService()
        {
            this.httpClient = new HttpClient();
        }

        List<Police> PoliceList = new();
        public async Task<List<Police>> GetPolices()
        {
            if (PoliceList?.Count > 0)
                return PoliceList;

            /*var response = await httpClient.GetAsync("https://localhost:7284/api/Person");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Basarili");
                PersonList = await response.Content.ReadFromJsonAsync(PersonContext.Default.ListPerson);
            }*/

            using var stream = await FileSystem.OpenAppPackageFileAsync("policedata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            PoliceList = JsonSerializer.Deserialize(contents, PoliceContext.Default.ListPolice);

            return PoliceList;
        }
    }
}
