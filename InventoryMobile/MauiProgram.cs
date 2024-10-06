using Camera.MAUI;
using InventoryMobile.Repositories.Login;
using InventoryMobile.Repositories.Product;
using InventoryMobile.Repositories.Signup;

namespace InventoryMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCameraView()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<SignupViewModel>();
		builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<AddProductViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<SignupPage>();
		builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<AddProductPage>();


        builder.Services.AddScoped<ILoginRepository, LoginRepository>();
		builder.Services.AddScoped<ISignupRepository, SignupRepository>();
		builder.Services.AddScoped<IProductRepository, ProductRepository>();

		return builder.Build(); 
	}
}
