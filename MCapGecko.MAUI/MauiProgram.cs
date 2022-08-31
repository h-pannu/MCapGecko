global using MCapGecko.SharedUI.ServiceInterfaces;
global using MCapGecko.Shared.Models;
using Microsoft.AspNetCore.Components.WebView.Maui;
using MCapGecko.SharedUI.Pages.WeatherData;
using MCapGecko.MAUI.Services;
using Syncfusion.Blazor;

namespace MCapGecko.MAUI
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            //Add your valid license key here.
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzA3ODE0QDMyMzAyZTMyMmUzMEdmMjBqbWJKSGRGb0k2OHEyRHY4VzJZa0Q5MjNSQ3RGRmFWUTdMUnBCWE09");
            builder.Services.AddScoped<ICoinService, CoinServiceMaui>();
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7075") });
            builder.Services.AddSingleton<IWeatherForecastService,WeatherForecastServiceMaui>();

            return builder.Build();
        }
    }
}