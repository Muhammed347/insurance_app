namespace deneme6.View;
using deneme6.ViewModel;

public partial class MyPoliceDetail : ContentPage
{
	public MyPoliceDetail(MyPoliceViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;       
    } 
}