using deneme6.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.ViewModel
{
    [QueryProperty(nameof(Id), "PersonId")]
    public partial class AddDaskModelView : BaseViewModel
    {
        public ObservableCollection<string> Products { get; set; } = new ObservableCollection<string>();
        
        private string selectedProduct;
        private string personId;

        private readonly ProductService productService;
        private readonly DaskService daskService;
        public AddDaskModelView(ProductService productService, DaskService daskService)
        {
            Title = "Add Policy";
            this.productService = productService;
            this.daskService = daskService;
            Task.Run(GetProductsAsync);
        }


        [ObservableProperty]
        string address;

        [ObservableProperty]
        string district;

        [ObservableProperty]
        string city;


        [ObservableProperty]
        string userId;

        [RelayCommand]
        public async Task AddClick()
        {
            try
            {
                IsBusy = true;

                
                Dask newDask = new Dask
                {
                    Adress = address,
                    District = district,
                    City = city,
                    ProductId = int.Parse(selectedProduct), 
                    PersonId = int.Parse(personId), 
                    StartDate = DateTime.Now, 
                    ExpiryDate = DateTime.Now.AddYears(1), 
                    Prim = new Random().Next(1000, 10000) 
            };

                // Post the new Dask object using the PostDask method in the DaskService
                await daskService.PostDask(newDask);

                Debug.WriteLine("Dask posted successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to post Dask. Please try again.", "OK");
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
