using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;
using System.Threading;
using System.Runtime.InteropServices;
using Syncfusion.Blazor.Sparkline.Internal;
using System.Collections;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace MCapGecko.Server.Services
{
    //class DecimalConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return (objectType == typeof(decimal) || objectType == typeof(decimal?));
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        JToken token = JToken.Load(reader);
    //        if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
    //        {
    //            return token.ToObject<decimal>();
    //        }
    //        if (token.Type == JTokenType.String)
    //        {
    //            // customize this to suit your needs
    //            return Decimal.Parse(token.ToString().TrimEnd('0'),
    //                   System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
    //        }
    //        if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
    //        {
    //            return null;
    //        }
    //        throw new JsonSerializationException("Unexpected token type: " +
    //                                              token.Type.ToString());
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class CoinGeckoService : ICoinGeckoService
    {
        public async Task<List<Coin>> GetCoinListAsync()
        {
            DataContext _contextDelete = new DataContext();
            List<Coin> list1 = _contextDelete.Coins.ToList();
            _contextDelete.Coins.RemoveRange(list1);
            _contextDelete.SaveChanges();
            try
            {
                List<Coin> coinList = new List<Coin>();
                for (int i = 1; i < 155; i++)
                {
                    //coinList = await client.GetFromJsonAsync<List<Coin>>("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=250&page=" + i.ToString() + "&sparkline=false");

                    var Url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=id_desc&per_page=250&page=" + i.ToString() + "&sparkline=false";

                    //HttpClientHandler clientHandler = new HttpClientHandler();
                    //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                    using (var client = new HttpClient())
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

                                //JsonSerializerSettings settings = new JsonSerializerSettings
                                //{
                                //    NullValueHandling = NullValueHandling.Ignore,
                                //    MissingMemberHandling = MissingMemberHandling.Ignore,
                                //    Formatting = Formatting.None,
                                //    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                                //    FloatParseHandling = FloatParseHandling.Decimal
                                //    //Converters = new List<JsonConverter> { new DecimalConverter() }
                                //};

                                coinList = JsonConvert.DeserializeObject<List<Coin>>(content);  //, settings

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
                                if(e.Message == "An attempt was made to access a socket in a way forbidden by its access permissions. (api.coingecko.com:443)")
                                {

                                }
                                Thread.Sleep(2000);
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
