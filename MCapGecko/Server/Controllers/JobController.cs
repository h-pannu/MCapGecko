using Hangfire;
using MCapGecko.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCapGecko.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ICoinGeckoService _coinGeckoService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        private readonly DataContext _context;
        public JobController(ICoinGeckoService coinGeckoService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, DataContext context)
        {
            _coinGeckoService = coinGeckoService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _context = context;
        }

        //https://code-maze.com/hangfire-with-asp-net-core/

        [HttpGet("/ReccuringJob")]
        public ActionResult CreateReccuringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _coinGeckoService.GetCoinListAsync(), Cron.Hourly);
            return Ok();
        }
    }
}
