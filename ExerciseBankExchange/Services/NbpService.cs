using AutoMapper;
using ExerciseBankExchange.Models;
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
        private readonly ILogger<NbpService> _logger;
        private readonly HttpClient _client;

        public NbpService(ILogger<NbpService> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _client = clientFactory.CreateClient("NbpRate170322");
        }
        public async Task<NbpTable> GetNbpEuroRate()
        {
            _logger.LogInformation($"Log message in the GetNbpEuroRate()() method");
            NbpTable nbpTable = new NbpTable();
            try
            {
                string responseBody
                    = await _client.GetStringAsync(_client.BaseAddress);
                
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
