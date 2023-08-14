using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Services
{
    public class KaskoService
    {
        private HttpClient httpClient;

        public KaskoService()
        {
            // Create an instance of HttpClientHandler and configure it to trust the secure certificate
            httpClient = CreateHttpClient();
        }

        List<Kasko> KaskoList = new List<Kasko>();

        public async Task<List<Kasko>> GetKaskoList()
        {
            if (KaskoList.Count > 0)
                return KaskoList;

            string kaskoUrl = "https://10.0.2.2:7284/api/Kasko";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(kaskoUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    KaskoList = JsonConvert.DeserializeObject<List<Kasko>>(responseBody);
                    Debug.WriteLine("Kasko list successfully readed");
                }
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
            }

            return KaskoList;
        }

        public async Task<List<Kasko>> GetKaskoWithId(int id)
        {
            try
            {
                List<Kasko> allKasko = await GetKaskoList();
                List<Kasko> kaskoWithId = allKasko.Where(k => k.PersonId == id).ToList();
                return kaskoWithId;
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
                return new List<Kasko>();
            }
        }

        public async Task DeleteKaskoWithId(int id)
        {
            try
            {
                // API endpoint URL for deleting the Kasko with the given ID
                string deleteKaskoUrl = $"https://10.0.2.2:7284/api/Kasko/{id}";

                // Send the DELETE request to the API endpoint
                HttpResponseMessage response = await httpClient.DeleteAsync(deleteKaskoUrl);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Kasko deleted successfully.");
                }
                else
                {
                    // If the DELETE request is not successful, display an error message
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete Kasko. Please try again.", "OK");
                    });
                }
            }
            catch
            {
                // If an exception occurs, display an error message
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
            }
        }

        public async Task PostKasko(Kasko newKasko)
        {
            try
            {
                // API endpoint URL for creating a new Kasko
                string createKaskoUrl = "https://10.0.2.2:7284/api/Kasko";

                // Serialize the newKasko object to JSON
                string serializedKasko = JsonConvert.SerializeObject(newKasko);

                // Create the HTTP content with the serialized Kasko data
                StringContent httpContent = new StringContent(serializedKasko, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint with the serialized Kasko data
                HttpResponseMessage response = await httpClient.PostAsync(createKaskoUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Kasko posted successfully.", "OK");
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to post Kasko. Please try again.", "OK");
                    });
                }
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
            }
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
