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
        private readonly INbpService _nbpService;

        public AccountController(
            ILogger<AccountController> logger, 
            IAccountService accountService,
            INbpService nbpService )
        {
            _accountService = accountService;
            _nbpService = nbpService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = await _accountService.GetAccount(id);
            var saldeEuro = await _nbpService.ExchangePlnToEuro(account.SaldoPl);//local table-> _accountService.CreateLocalAccountTable()

            return Ok($"{saldeEuro} EUR");
        }
    }
}
