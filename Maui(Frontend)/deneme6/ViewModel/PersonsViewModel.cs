using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using deneme6.Services;
using deneme6.View;

namespace deneme6.ViewModel
{
    public partial class PersonsViewModel : BaseViewModel
    {
        public ObservableCollection<Person> Persons { get; } = new();
        PersonService personService;
        public PersonsViewModel(PersonService personService)
        {
            Title = "login";
            this.personService = personService;
        }

        [RelayCommand]
        async Task GetPersonsAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var persons = await personService.GetPersons();

                if (Persons.Count != 0)
                    Persons.Clear();

                foreach (var person in persons)
                    Persons.Add(person);

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

        
        public async Task ControlAsync(string name, string password)
        {
            await GetPersonsAsync();
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                // Find the person with the entered name in the Persons collection
                var person = Persons.FirstOrDefault(p => p.Name == name);

                if (person == null)
                {
                    await Shell.Current.DisplayAlert("Error", "User not found", "OK");
                    return;
                }

                // Check if the entered password matches the person's password
                if (person.Password == password)
                {
                    // Navigate to the home page or perform other actions as needed
                    // For example, you can use Shell navigation:
                    await Shell.Current.GoToAsync($"{nameof(MainPage)}?personId={person.PersonId}");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Incorrect password", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"There is an error: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
