using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deneme6.Services;
using deneme6.View;

namespace deneme6.ViewModel
{
    [QueryProperty(nameof(PersonId), "personId")]
    public partial class PoliceViewModel : BaseViewModel
    {
        public ObservableCollection<Police> Polices { get; } = new();
        PoliceService policeService { get; set; }

        private string personId { get; set; }

        public PoliceViewModel(PoliceService policeService)
        {
            Title = "Policeler sayfasi";
            this.policeService = policeService;
        }


        public string PersonId
        {
            get => personId;
            set
            {
                personId = value;
                
            }
        }

        [RelayCommand]
        async Task GoPolicesDetail()
        {
            await Shell.Current.GoToAsync($"{nameof(MyPoliceDetail)}?PersonId={PersonId}");
        }

        [RelayCommand]
        async Task GoAddDaskPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddDask)}?PersonId={PersonId}");
        }

        [RelayCommand]
        async Task GoAddKaskoPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddKasko)}?PersonId={PersonId}");
        }

        [RelayCommand]
        async Task GoAddTrafficPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTraffic)}?PersonId={PersonId}");
        }



        [RelayCommand]
        async Task GetPolicesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var polices = await policeService.GetPolices();

                if (Polices.Count != 0)
                    Polices.Clear();

                foreach (var police in polices)
                    Polices.Add(police);

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
        async Task GoToDetails(Police police)
        {
            if (police == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Police", police }
            });
        }

    }    
}
