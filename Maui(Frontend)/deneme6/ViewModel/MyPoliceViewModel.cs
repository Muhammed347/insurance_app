using deneme6.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme6.ViewModel
{
    [QueryProperty(nameof(Id), "PersonId")]
    public partial class MyPoliceViewModel : BaseViewModel
    {
        private string personId;

        public ObservableCollection<Dask> Dasks { get; } = new ObservableCollection<Dask>();
        DaskService daskService;
        public ObservableCollection<Kasko> Kaskos { get; } = new ObservableCollection<Kasko>();
        KaskoService kaskoService;
        public ObservableCollection<Traffic> Traffics { get; } = new ObservableCollection<Traffic>();
        TrafficService trafficService;
        public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();
        ProductService productService;

        public ObservableCollection<PolicyDask> PolicyDasks { get; } = new ObservableCollection<PolicyDask>();
        public ObservableCollection<PolicyTraffic> PolicyTraffics { get; } = new ObservableCollection<PolicyTraffic>();
        public ObservableCollection<PolicyKasko> PolicyKaskos { get; } = new ObservableCollection<PolicyKasko>();
        public MyPoliceViewModel(DaskService daskService, ProductService productService, TrafficService trafficService, KaskoService kaskoService)
        {
            Title = "Policelerim";
            this.daskService = daskService;
            this.productService = productService;
            this.trafficService = trafficService;
            this.kaskoService = kaskoService;
            //Task.Run(GetDasksWithIdAsync);
            //Task.Run(GetKaskosWithIdAsync);
            //Task.Run(GetTrafficsWithIdAsync);
            
        }


        //-------------------------------------Dask methods--------------------------------------

        [RelayCommand]
        async Task GetDasksAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var dasks = await daskService.GetDasks();

                if (Dasks.Count != 0)
                    Dasks.Clear();

                foreach (var dask in dasks)
                    Dasks.Add(dask);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetDasksWithIdAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var dasks = await daskService.GetDasksWithId(int.Parse(personId));

                // Create a new list to hold the products for the policy
                var newProductsList = new List<Product>();

                // Clear the existing collections outside the loop
                Dasks.Clear();
                Products.Clear();
                PolicyDasks.Clear();

                foreach (var dask in dasks)
                {
                    Dasks.Add(dask);

                    // Fetch the products for each dask and add them to the newProductsList
                    var products = await productService.GetProductsWithId(dask.ProductId);
                    foreach (var product in products)
                        newProductsList.Add(product);

                    PolicyDasks.Add(new PolicyDask
                    {
                        DaskId = dask.DaskId,
                        District = dask.District,
                        City = dask.City,
                        StartDate = dask.StartDate,
                        ExpiryDate = dask.ExpiryDate,
                        Prim = dask.Prim,
                        Code = newProductsList[0].Code,
                        Name = newProductsList[0].Name,
                    });
                }

                // Add all products from the newProductsList to the Products collection
                foreach (var product in newProductsList)
                    Products.Add(product);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                await GetTrafficsWithIdAsync();
            }

        }

        [RelayCommand]
        async Task DeleteDaskAsync(int id)
        {
            if (IsBusy)
                return;

            try
            {
                bool isConfirmed = await Shell.Current.DisplayAlert("Confirmation", "Are you sure you want to delete this Dask policy?", "OK", "Cancel");

                if (!isConfirmed)
                    return;

                IsBusy = true;

                // Call the DeleteDasksWithId method in the DaskService to delete the Dask by its ID
                await daskService.DeleteDasksWithId(id);

                // After the successful deletion, remove the Dask from the Dasks collection
                GetDasksAsync();
                Debug.WriteLine("Dask deleted successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


        //------------------------------------------Traffic methods--------------------------------------
        [RelayCommand]
        async Task GetTrafficsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var traffics = await trafficService.GetTrafficList();

                if (Traffics.Count != 0)
                    Traffics.Clear();

                foreach (var traffic in traffics)
                    Traffics.Add(traffic);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetTrafficsWithIdAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var traffics = await trafficService.GetTrafficWithId(int.Parse(personId));

                // Create a new list to hold the products for the policy
                var newProductsList = new List<Product>();

                // Clear the existing collections outside the loop
                Traffics.Clear();
                Products.Clear();
                PolicyTraffics.Clear();

                foreach (var traffic in traffics)
                {
                    Traffics.Add(traffic);

                    // Fetch the products for each traffic and add them to the newProductsList
                    var products = await productService.GetProductsWithId(traffic.ProductId);
                    foreach (var product in products)
                        newProductsList.Add(product);

                    PolicyTraffics.Add(new PolicyTraffic
                    {
                        TrafficId = traffic.TrafficId,
                        PlateCityCode = traffic.PlateCityCode,
                        PlateCode = traffic.PlateCode,
                        StartDate = traffic.StartDate,
                        ExpiryDate = traffic.ExpiryDate,
                        Prim = traffic.Prim,
                        Code = newProductsList[0].Code,
                        Name = newProductsList[0].Name,
                    });
                }

                // Add all products from the newProductsList to the Products collection
                foreach (var product in newProductsList)
                    Products.Add(product);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                await GetKaskosWithIdAsync();
            }

        }

        [RelayCommand]
        async Task DeleteTrafficAsync(int id)
        {
            if (IsBusy)
                return;

            try
            {
                bool isConfirmed = await Shell.Current.DisplayAlert("Confirmation", "Are you sure you want to delete this traffic policy?", "OK", "Cancel");

                if (!isConfirmed)
                    return;

                IsBusy = true;

                // Call the DeleteTrafficsWithId method in the TrafficService to delete the Traffic by its ID
                await trafficService.DeleteTrafficWithId(id);

                // After the successful deletion, remove the Traffic from the Traffics collection
                GetTrafficsAsync();
                Debug.WriteLine("Traffic deleted successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        //-----------------------------kasko methods--------------------------------

        [RelayCommand]
        async Task GetKaskosAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var kaskos = await kaskoService.GetKaskoList();

                if (Kaskos.Count != 0)
                    Kaskos.Clear();

                foreach (var kasko in kaskos)
                    Kaskos.Add(kasko);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GetKaskosWithIdAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var kaskos = await kaskoService.GetKaskoWithId(int.Parse(personId));

                // Create a new list to hold the products for the policy
                var newProductsList = new List<Product>();

                // Clear the existing collections outside the loop
                Kaskos.Clear();
                Products.Clear();
                PolicyKaskos.Clear();

                foreach (var kasko in kaskos)
                {
                    Kaskos.Add(kasko);

                    // Fetch the products for each kasko and add them to the newProductsList
                    var products = await productService.GetProductsWithId(kasko.ProductId);
                    foreach (var product in products)
                        newProductsList.Add(product);

                    PolicyKaskos.Add(new PolicyKasko
                    {
                        KaskoId = kasko.KaskoId,
                        VehicleModel = kasko.VehicleModel,
                        VehicleBrand = kasko.VehicleBrand,
                        StartDate = kasko.StartDate,
                        ExpiryDate = kasko.ExpiryDate,
                        Prim = kasko.Prim,
                        Code = newProductsList[0].Code,
                        Name = newProductsList[0].Name,
                    });
                }

                // Add all products from the newProductsList to the Products collection
                foreach (var product in newProductsList)
                    Products.Add(product);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [RelayCommand]
        async Task DeleteKaskoAsync(int id)
        {
            if (IsBusy)
                return;

            try
            {
                bool isConfirmed = await Shell.Current.DisplayAlert("Confirmation", "Are you sure you want to delete this Kasko policy?", "OK", "Cancel");

                if (!isConfirmed)
                    return;

                IsBusy = true;

                // Call the DeleteKaskosWithId method in the KaskoService to delete the Kasko by its ID
                await kaskoService.DeleteKaskoWithId(id);

                // After the successful deletion, remove the Kasko from the Kaskos collection
                GetKaskosAsync();
                Debug.WriteLine("Kasko deleted successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
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
    }
}
