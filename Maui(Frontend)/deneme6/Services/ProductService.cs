using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.Services
{
    public class ProductService
    {
        private HttpClient httpClient;

        public ProductService()
        {
            // Create an instance of HttpClientHandler and configure it to trust the secure certificate
            httpClient = CreateHttpClient();
        }

        List<Product> ProductList = new();
        public async Task<List<Product>> GetProducts()
        {
            if (ProductList?.Count > 0)
                return ProductList;

            string ProductListUrl = "https://10.0.2.2:7284/api/Product";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(ProductListUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ProductList = JsonConvert.DeserializeObject<List<Product>>(responseBody);
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

            return ProductList;

        }

        public async Task<List<Product>> GetProductsWithId(int id)
        {
            try
            {
                List<Product> allProducts = await GetProducts();
                List<Product> productsWithId = allProducts.Where(d => d.ProductId == id).ToList();
                return productsWithId;
            }
            catch
            {
                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "something went wrong try again", "ok");
                });
                return new List<Product>();
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
