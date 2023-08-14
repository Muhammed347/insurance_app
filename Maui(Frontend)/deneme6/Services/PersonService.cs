using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace deneme6.Services
{
    public class PersonService
    {
        private HttpClient httpClient;
        
        public PersonService()
        {
            // Create an instance of HttpClientHandler and configure it to trust the secure certificate
            httpClient = CreateHttpClient();
        }

        List<Person> PersonList = new();
        public async Task<List<Person>> GetPersons()
        {
            if (PersonList?.Count > 0)
                return PersonList;

            string PersonUrl = "https://10.0.2.2:7284/api/Person";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(PersonUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    PersonList = JsonConvert.DeserializeObject<List<Person>>(responseBody);
                    Debug.WriteLine("succesfully readed");
                }

            }
            catch
            {

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "something went wrong try again", "ok");
                });

            }

            return PersonList;

        }

        private HttpClient CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            };

            return new HttpClient(httpClientHandler);
        }
    }
}
