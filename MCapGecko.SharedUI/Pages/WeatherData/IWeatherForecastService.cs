using MCapGecko.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MCapGecko.SharedUI.Pages.WeatherData
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]?> GetWeatherForecastAsync();
    }
}
