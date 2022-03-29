using AutoMapper;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services
{
    public class Exchanger : IExchanger
    {
        private readonly ILogger<Exchanger> _logger;
        private readonly INbpService _nbpService;
        private readonly IAccountService _accountService;

        public Exchanger(ILogger<Exchanger> logger, INbpService nbpService, IAccountService accountService)
        {
            _logger = logger;
            _nbpService = nbpService;
            _accountService = accountService;
        }
        public async Task<decimal> ExchangePlnToEuro(int id)
        {
            _logger.LogInformation($"Log message in the ExchangePlnToEuro({id})() method");
            var account = await _accountService.GetAccount(id);
            var euroRate = await _nbpService.GetNbpEuroRate();
            var saldeEuro = (decimal)account.SaldoPl / euroRate.rates.FirstOrDefault().mid;
           
            return Math.Round(saldeEuro, 2, MidpointRounding.AwayFromZero);
        }
    }
}
