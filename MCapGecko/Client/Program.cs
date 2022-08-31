global using MCapGecko.SharedUI.ServiceInterfaces;
global using MCapGecko.Shared.Models;
using MCapGecko.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MCapGecko.SharedUI.Pages.WeatherData;
using MCapGecko.Client.Services;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICoinService, CoinService>();

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

//Add your valid license key here.
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzA3ODE0QDMyMzAyZTMyMmUzMEdmMjBqbWJKSGRGb0k2OHEyRHY4VzJZa0Q5MjNSQ3RGRmFWUTdMUnBCWE09");

await builder.Build().RunAsync();
