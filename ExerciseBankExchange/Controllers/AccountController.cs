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
        private readonly IAccountService _accountService;
        private readonly IExchanger _exchanger;

        public AccountController(
            ILogger<AccountController> logger, 
            IAccountService accountService,
            IExchanger exchanger )
        {
            _accountService = accountService;
            _exchanger = exchanger;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEuroSaldoAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _accountService.GetAccount(id);
            var saldeEuro = await _exchanger.ExchangePlnToEuro(account.SaldoPl);//local table-> _accountService.CreateLocalAccountTable()

            return Ok($"{saldeEuro} EUR");
        }
    }
}
