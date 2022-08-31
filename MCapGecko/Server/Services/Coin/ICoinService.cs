using MCapGecko.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCapGecko.Server.Services
{
    public interface ICoinService
    {
        Task<List<Coin>> GetCoinsAsync();
    }
}
