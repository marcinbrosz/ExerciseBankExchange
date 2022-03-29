using ExerciseBankExchange.Services;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ExerciseBankExchange.Tests
{
    public class NbpServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task TestExchangePlnToEuro()
        {
            var mockLogger = new Mock<ILogger<Exchanger>>();
            var nbpService = new Mock<INbpService>();

            var exchanger = new Exchanger(mockLogger.Object, nbpService.Object);
            var result = await exchanger.ExchangePlnToEuro(500);

            Assert.AreEqual(106.66, result);
        }

    }
}
