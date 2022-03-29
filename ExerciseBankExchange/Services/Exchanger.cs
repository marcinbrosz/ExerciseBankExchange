using AutoMapper;
using ExerciseBankExchange.Entities.Models;
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

        public Exchanger(ILogger<Exchanger> logger, INbpService nbpService)
        {
            _logger = logger;
            _nbpService = nbpService;
        }
        public async Task<decimal> ExchangePlnToEuro(double saldePln)
        {
            var euroRate = await _nbpService.GetNbpEuroRate();
            var saldeEuro = saldePln / euroRate.rates.FirstOrDefault().mid;

            return (decimal)Math.Round(saldeEuro, 2, MidpointRounding.AwayFromZero);
        }
    }
}
