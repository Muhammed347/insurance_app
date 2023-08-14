using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Services
{
    public class TrafficService
    {
        private HttpClient httpClient;

        public TrafficService()
        {
            // Create an instance of HttpClientHandler and configure it to trust the secure certificate
            httpClient = CreateHttpClient();
        }

        List<Traffic> TrafficList = new List<Traffic>();

        public async Task<List<Traffic>> GetTrafficList()
        {
            if (TrafficList.Count > 0)
                return TrafficList;

            string trafficUrl = "https://10.0.2.2:7284/api/Traffic";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(trafficUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    TrafficList = JsonConvert.DeserializeObject<List<Traffic>>(responseBody);
                    Debug.WriteLine("Traffic list successfully readed");
                }
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
            }

            return TrafficList;
        }

        public async Task<List<Traffic>> GetTrafficWithId(int id)
        {
            try
            {
                List<Traffic> allTraffic = await GetTrafficList();
                List<Traffic> trafficWithId = allTraffic.Where(t => t.PersonId == id).ToList();
                return trafficWithId;
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
                });
                return new List<Traffic>();
            }
        }

        public async Task DeleteTrafficWithId(int id)
        {
            try
            {
                // API endpoint URL for deleting the Traffic with the given ID
                string deleteTrafficUrl = $"https://10.0.2.2:7284/api/Traffic/{id}";

                // Send the DELETE request to the API endpoint
                HttpResponseMessage response = await httpClient.DeleteAsync(deleteTrafficUrl);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Traffic deleted successfully.");
                }
                else
                {
                    // If the DELETE request is not successful, display an error message
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete Traffic. Please try again.", "OK");
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

        public async Task PostTraffic(Traffic newTraffic)
        {
            try
            {
                // API endpoint URL for creating a new Traffic
                string createTrafficUrl = "https://10.0.2.2:7284/api/Traffic";

                // Serialize the newTraffic object to JSON
                string serializedTraffic = JsonConvert.SerializeObject(newTraffic);

                // Create the HTTP content with the serialized Traffic data
                StringContent httpContent = new StringContent(serializedTraffic, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint with the serialized Traffic data
                HttpResponseMessage response = await httpClient.PostAsync(createTrafficUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Traffic posted successfully.", "OK");
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to post Traffic. Please try again.", "OK");
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
