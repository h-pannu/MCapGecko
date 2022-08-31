using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCapGecko.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ICoinService _coinService;

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Coin>>> GetCoins()
        {
            var result =  await _coinService.GetCoinsAsync();
            return Ok(result);
        }
    }
}
