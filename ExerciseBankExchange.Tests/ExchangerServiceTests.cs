using ExerciseBankExchange.Models;
using ExerciseBankExchange.Services;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExerciseBankExchange.Tests
{
    public class ExchangerServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task ExchangePlnToEuro()
        {
            var mockLogger = new Mock<ILogger<Exchanger>>();
            var nbpService = new Mock<INbpService>();

            var ratesList = new List<Rates>();
            ratesList.Add(new Rates { mid = new decimal(4.6876) });
            var nbpTable = new NbpTable() 
            { 
                rates = ratesList
            };

            nbpService
                .Setup(x => x.GetNbpEuroRate())
                .ReturnsAsync(nbpTable);

            var accountService = new Mock<IAccountService>();

            accountService
                .Setup(x => x.GetAccount(It.IsAny<int>()))
                .ReturnsAsync(new Models.Dtos.AccountDto() { SaldoPl = 500 });

            var exchanger = new Exchanger(mockLogger.Object, nbpService.Object, accountService.Object);
            var result = await exchanger.ExchangePlnToEuro(2);

            Assert.AreEqual(106.66, result);
        }

    }
}
