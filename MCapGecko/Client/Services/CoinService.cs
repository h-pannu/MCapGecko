using MCapGecko.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace MCapGecko.Client.Services
{
    public class CoinService : ICoinService
    {
        private readonly HttpClient _httpClient;
        public CoinService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Coin> Coins { get; set; }

        public async Task<List<Coin>> GetCoins()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Coin>>("api/coin");
            return result;
        }
    }
}
