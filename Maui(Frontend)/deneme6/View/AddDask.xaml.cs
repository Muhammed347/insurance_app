using deneme6.ViewModel;
namespace deneme6.View;

public partial class AddDask : ContentPage
{
	public AddDask(AddDaskModelView viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}