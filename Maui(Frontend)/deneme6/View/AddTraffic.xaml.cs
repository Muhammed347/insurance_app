using deneme6.ViewModel;

namespace deneme6.View;

public partial class AddTraffic : ContentPage
{
	public AddTraffic(AddTrafficModelView viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}