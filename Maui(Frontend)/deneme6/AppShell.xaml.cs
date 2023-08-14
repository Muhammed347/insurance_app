using deneme6.View;

namespace deneme6;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(MyPoliceDetail), typeof(MyPoliceDetail));
        Routing.RegisterRoute(nameof(AddDask), typeof(AddDask));
        Routing.RegisterRoute(nameof(AddTraffic), typeof(AddTraffic));
        Routing.RegisterRoute(nameof(AddKasko), typeof(AddKasko));
    }
}
