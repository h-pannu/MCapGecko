
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MCapGecko.MAUI.Services
{
    public class CoinServiceMaui : ICoinService
    {
        private readonly HttpClient _httpClient;
        public CoinServiceMaui(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Coin> Coins { get; set; }

        public async Task<List<Coin>> GetCoins()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<Coin>>("api/coin");
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
