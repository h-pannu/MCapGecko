using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCapGecko.Shared.Models;

namespace MCapGecko.SharedUI.ServiceInterfaces
{
    public interface ICoinService
    {
        List<Coin> Coins { get; set; }
        Task<List<Coin>> GetCoins();
    }
}
