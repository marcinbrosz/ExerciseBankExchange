using ExerciseBankExchange.Services;
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
        public async System.Threading.Tasks.Task TestResultBadRequestResult2Async()
        {
            var mockLogger = new Mock<ILogger<NbpService>>();

            var nbpService = new NbpService(mockLogger.Object);
            var result = await nbpService.ExchangePlnToEuro(500);

            Assert.AreEqual(106.66, result);
        }
    }
}
