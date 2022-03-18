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
    public class NbpService: INbpService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly ILogger<NbpService> _logger;
        private const string Url = "https://api.nbp.pl/api/exchangerates/rates/a/eur/2022-03-17/?format=json";

        public NbpService(ILogger<NbpService> logger)
        {
            _logger = logger;
        }
        public async Task<double> ExchangePlnToEuro(double saldePln)
        {
            var euroRate = await GetNbpEuroRate();
            var saldeEuro = saldePln / euroRate.rates.FirstOrDefault().mid;

            return Math.Round(saldeEuro, 2, MidpointRounding.AwayFromZero);
        }
        public async Task<NbpTable> GetNbpEuroRate()
        {
            NbpTable nbpTable = new NbpTable();
            try
            {
                string responseBody 
                    = await _client.GetStringAsync(Url);

                nbpTable =
                    JsonSerializer.Deserialize<NbpTable>(responseBody);
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Message :{0} ", e.Message);
            }

            return nbpTable;

        }
    }
}
