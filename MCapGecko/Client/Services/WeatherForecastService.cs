using MCapGecko.Shared;
using MCapGecko.SharedUI.Pages.WeatherData;
using System.Net.Http.Json;

namespace MCapGecko.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient http;

        public WeatherForecastService(HttpClient http)
        {
            this.http = http;
        }
        public Task<WeatherForecast[]?> GetWeatherForecastAsync()
        {
            return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
    }
}
