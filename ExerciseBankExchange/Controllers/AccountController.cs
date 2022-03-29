using ExerciseBankExchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IExchanger _exchanger;

        public AccountController(
            ILogger<AccountController> logger, 
            IExchanger exchanger )
        {
            _exchanger = exchanger;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEuroSaldoAsync(int id)
        {
            _logger.LogInformation($"Log message in the GetEuroSaldoAsync({id})() method");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saldeEuro = await _exchanger.ExchangePlnToEuro(id);

            return Ok($"{saldeEuro} EUR");
        }
    }
}
