using Microsoft.EntityFrameworkCore;
using MCapGecko.Shared.Models;

namespace MCapGecko.Server.Services
{
    public interface ICoinGeckoService
    {
        Task<List<Coin>> GetCoinListAsync();
    }
}
