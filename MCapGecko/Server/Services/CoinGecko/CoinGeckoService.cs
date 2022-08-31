using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Runtime.InteropServices;

namespace MCapGecko.Server.Services
{
    public class CoinGeckoService : ICoinGeckoService
    {
        public async Task<List<Coin>> GetCoinListAsync()
        {
            //HttpClient client = new HttpClient();
            try
            {
                List<Coin> coinList = new List<Coin>();
                for (int i = 1; i < 55; i++)
                {
                    //coinList = await client.GetFromJsonAsync<List<Coin>>("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=250&page=" + i.ToString() + "&sparkline=false");

                    var Url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=250&page=" + i.ToString() + "&sparkline=false";

                    HttpClientHandler clientHandler = new HttpClientHandler();
                    clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                    using (var client = new HttpClient(clientHandler))
                    {
                        int count = 0;
                        int maxTries = 300;
                        while (true)
                        {
                            try
                            {
                                DataContext _context = new DataContext();
                                Thread.Sleep(2000);
                                var content = await client.GetStringAsync(Url);
                                coinList = JsonConvert.DeserializeObject<List<Coin>>(content);

                                if (coinList != null)
                                {
                                    foreach (var coin in coinList.OrderBy(i => i.market_cap_rank))
                                    {
                                        _context.Coins.Add(coin);
                                    }
                                }

                                await _context.SaveChangesAsync();
                                int d = _context.Coins.Count();

                                break;
                            }
                            catch (Exception e)
                            {
                                Thread.Sleep(40000);
                                // handle exception
                                if (++count == maxTries) throw e;
                            }
                        }
                    }
                }
                return coinList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
