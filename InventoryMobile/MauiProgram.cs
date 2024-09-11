using InventoryMobile.Repositories.Login;

namespace InventoryMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddScoped<ILoginRepository, LoginRepository>();

		return builder.Build();
	}
}
