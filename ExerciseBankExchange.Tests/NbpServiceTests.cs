using ExerciseBankExchange.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Tests
{
    public class NbpServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetExchangeRate_Date180322Async()
        {
            var _httpMessageHandler = new Mock<HttpMessageHandler>();


            _httpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                   "SendAsync",
                   ItExpr.IsAny<HttpRequestMessage>(),
                   ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(new HttpResponseMessage
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent("{\"table\":\"A\",\"currency\":\"euro\",\"code\":\"EUR\",\"rates\":[{\"no\":\"053/A/NBP/2022\",\"effectiveDate\":\"2022-03-17\",\"mid\":4.6876}]}")
               })
               .Verifiable();

            var httpClient = new HttpClient(_httpMessageHandler.Object);
            httpClient.BaseAddress = new Uri("https://api.nbp.pl/api/exchangerates/rates/a/eur/2022-03-17/?format=json");
            
            var mockLogger = new Mock<ILogger<NbpService>>();
            var httpClientFactory = new Mock<IHttpClientFactory>();

            httpClientFactory
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var nbpService = new NbpService(mockLogger.Object, httpClientFactory.Object);

            var rate = await nbpService.GetNbpEuroRate();

            Assert.AreEqual(4.6876, rate.rates.FirstOrDefault().mid);

        }
    }
}
