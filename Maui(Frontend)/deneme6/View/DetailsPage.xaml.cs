using deneme6.ViewModel;

namespace deneme6.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(PoliceDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}