using MCapGecko.Shared;
using MCapGecko.SharedUI.Pages.WeatherData;
using System.Net.Http.Json;

namespace MCapGecko.MAUI.Services
{
    public class WeatherForecastServiceMaui : IWeatherForecastService
    {
        private readonly HttpClient http;

        public WeatherForecastServiceMaui(HttpClient http)
        {
            this.http = http;
        }
        public Task<WeatherForecast[]> GetWeatherForecastAsync()
        {
            return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
