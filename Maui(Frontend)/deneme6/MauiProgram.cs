using Microsoft.Extensions.Logging;
using deneme6.View;
using deneme6.Services;
using deneme6.ViewModel;

namespace deneme6;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


#if DEBUG
		builder.Logging.AddDebug();
#endif
        builder.Services.AddTransient<PoliceDetailsViewModel>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<MyPoliceViewModel>();
        builder.Services.AddTransient<MyPoliceDetail>();
        builder.Services.AddSingleton<PoliceService>();
        builder.Services.AddSingleton<PoliceViewModel>();
        builder.Services.AddSingleton<PersonService>();
        builder.Services.AddSingleton<DaskService>();
        builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<KaskoService>();
        builder.Services.AddSingleton<TrafficService>();
        builder.Services.AddSingleton<PersonsViewModel>();
        builder.Services.AddSingleton<AddDask>();
        builder.Services.AddSingleton<AddDaskModelView>();
        builder.Services.AddSingleton<AddKasko>();
        builder.Services.AddSingleton<AddKaskoModelView>();
        builder.Services.AddSingleton<AddTraffic>();
        builder.Services.AddSingleton<AddTrafficModelView>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();

        return builder.Build();
	}
}
