using deneme6.ViewModel;

namespace deneme6.View;

public partial class AddKasko : ContentPage
{
	public AddKasko(AddKaskoModelView viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}