
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;


namespace MCapGecko.Server.Services
{
    public class CoinService : ICoinService
    {
        private readonly DataContext _context;

        public CoinService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Coin>> GetCoinsAsync()
        {
            var coinList = await _context.Coins.OrderByDescending(i=>i.market_cap_rank).ToListAsync();
            return coinList;
            
        }
    }
}
