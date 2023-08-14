using deneme6.ViewModel;

namespace deneme6.View;

public partial class MainPage : ContentPage
{
	public MainPage(PoliceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}