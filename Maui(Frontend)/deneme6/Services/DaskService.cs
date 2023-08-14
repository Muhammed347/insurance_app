using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Services
{
    public class DaskService
    {
        private HttpClient httpClient;

        public DaskService()
        {
            // Create an instance of HttpClientHandler and configure it to trust the secure certificate
            httpClient = CreateHttpClient();
        }

        List<Dask> DaskList = new();
        public async Task<List<Dask>> GetDasks()
        {
            if (DaskList?.Count > 0)
                return DaskList;

            string DaskUrl = "https://10.0.2.2:7284/api/Dask";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(DaskUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    DaskList = JsonConvert.DeserializeObject<List<Dask>>(responseBody);
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

            return DaskList;

        }

        public async Task<List<Dask>> GetDasksWithId(int id)
        {
            try
            {
                List<Dask> allDasks = await GetDasks();
                List<Dask> dasksWithId = allDasks.Where(d => d.PersonId == id).ToList();
                return dasksWithId;
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "something went wrong try again", "ok");
                });
                return new List<Dask>();
            }
        }

        public async Task DeleteDasksWithId(int id)
        {
            try
            {
                // API endpoint URL for deleting the Dask with the given ID
                string deleteDaskUrl = $"https://10.0.2.2:7284/api/Dask/{id}";

                // Send the DELETE request to the API endpoint
                HttpResponseMessage response = await httpClient.DeleteAsync(deleteDaskUrl);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Dask deleted successfully.");               
                }
                else
                {
                    // If the DELETE request is not successful, display an error message
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to delete Dask. Please try again.", "OK");
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


        public async Task PostDask(Dask newDask)
        {
            try
            {
                // API endpoint URL for creating a new Dask
                string createDaskUrl = "https://10.0.2.2:7284/api/Dask";

                // Serialize the newDask object to JSON
                string serializedDask = JsonConvert.SerializeObject(newDask);

                // Create the HTTP content with the serialized Dask data
                StringContent httpContent = new StringContent(serializedDask, Encoding.UTF8, "application/json");

                // Send the POST request to the API endpoint with the serialized Dask data
                HttpResponseMessage response = await httpClient.PostAsync(createDaskUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Dask posted successfully.", "OK");
                }
                else
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Failed to post Dask. Please try again.", "OK");
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

