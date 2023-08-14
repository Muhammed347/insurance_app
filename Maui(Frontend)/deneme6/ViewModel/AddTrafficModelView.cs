using deneme6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.ViewModel
{
    [QueryProperty(nameof(Id), "PersonId")]
    public partial class AddTrafficModelView : BaseViewModel
    {
        public ObservableCollection<string> Products { get; set; } = new ObservableCollection<string>();

        private string selectedProduct;
        private string personId;

        private readonly ProductService productService;
        private readonly TrafficService trafficService;
        public AddTrafficModelView(ProductService productService, TrafficService trafficService)
        {
            Title = "Add Traffic Policy";
            this.productService = productService;
            this.trafficService = trafficService;
            Task.Run(GetProductsAsync);
        }

        [ObservableProperty]
        string plateCityCode;

        [ObservableProperty]
        string plateCode;

        [ObservableProperty]
        string userId;

        [RelayCommand]
        public async Task AddClick()
        {
            try
            {
                IsBusy = true;

                Traffic newTraffic = new Traffic
                {
                    PlateCityCode = plateCityCode,
                    PlateCode = plateCode,
                    ProductId = int.Parse(selectedProduct),
                    PersonId = int.Parse(personId),
                    StartDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddYears(1),
                    Prim = new Random().Next(1000, 10000)
                };

                // Post the new Traffic object using the PostTraffic method in the TrafficService
                await trafficService.PostTraffic(newTraffic);

                Debug.WriteLine("Traffic policy posted successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to post Traffic policy. Please try again.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GetProductsAsync()
        {
            try
            {
                IsBusy = true;

                var products = await productService.GetProducts();

                if (Products.Count > 0)
                    Products.Clear();

                foreach (var product in products)
                    Products.Add(product.ProductId.ToString()); // Convert the ProductId to a string and add it to the collection
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public string Id
        {
            get => personId;
            set
            {
                personId = value;
            }
        }

        public string SelectedProduct
        {
            get => selectedProduct;
            set
            {
                if (selectedProduct != value)
                {
                    selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }
    }

}
