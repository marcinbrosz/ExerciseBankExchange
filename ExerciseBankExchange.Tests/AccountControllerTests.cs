using ExerciseBankExchange.Controllers;
using ExerciseBankExchange.Models.Dtos;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace ExerciseBankExchange.Tests
{
    public class Tests
    {
        private AccountController _accountController;

        [SetUp]
        public void Setup()
        {
            decimal returnValue = 123;
            var mockLogger = new Mock<ILogger<AccountController>>();
            var exchanger = new Mock<IExchanger>();

            exchanger
                .Setup(x => x.ExchangePlnToEuro(It.IsAny<int>()))
                .ReturnsAsync(returnValue);

            _accountController
                = new AccountController(mockLogger.Object, exchanger.Object);
        }

        [Test]
        public void GetOkObjectResult()
        {
            var result = _accountController.GetEuroSaldoAsync(2).Result;
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public void GetBadRequestObjectResult()
        {
            _accountController.ModelState.AddModelError("Name", "Required");
            var result = _accountController.GetEuroSaldoAsync(2).Result;
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }


    }
}