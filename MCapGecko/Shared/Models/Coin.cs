using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCapGecko.Shared.Models
{
    public class Coin
    {
        public string id { get; set; }=String.Empty;
        public string symbol { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string image { get; set; } = String.Empty;
        public double? current_price { get; set; }
        public long? market_cap { get; set; } = 0;
        public int? market_cap_rank { get; set; }
        public long? fully_diluted_valuation { get; set; } = 0;
        public double? total_volume { get; set; }
        public double? high_24h { get; set; }
        public double? low_24h { get; set; }
        public double? price_change_24h { get; set; }
        public double? price_change_percentage_24h { get; set; }
        public double? market_cap_change_24h { get; set; }
        public double? market_cap_change_percentage_24h { get; set; }
        public double? circulating_supply { get; set; }
        public double? total_supply { get; set; }
        public double? max_supply { get; set; }
        public double? ath { get; set; }
        public double? ath_change_percentage { get; set; }
        public DateTime? ath_date { get; set; }
        public double? atl { get; set; }
        public double? atl_change_percentage { get; set; }
        public DateTime? atl_date { get; set; }
        public DateTime? last_updated { get; set; }
    }
}
