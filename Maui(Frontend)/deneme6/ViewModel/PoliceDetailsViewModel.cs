using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace deneme6.ViewModel
{
    [QueryProperty(nameof(Police), "Police")]
    public partial class PoliceDetailsViewModel : BaseViewModel
    {
        public PoliceDetailsViewModel()
        {

        }

        [ObservableProperty]
        Police police;

    }
}
