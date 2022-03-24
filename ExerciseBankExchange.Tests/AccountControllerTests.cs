using ExerciseBankExchange.Controllers;
using ExerciseBankExchange.Dtos;
using ExerciseBankExchange.Entities.Models;
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
            double returnValue = 123;
            var mockLogger = new Mock<ILogger<AccountController>>();
            var accountService = new Mock<IAccountService>();
            var nbpService = new Mock<INbpService>();

            accountService
                .Setup(x => x.GetAccount(It.IsAny<int>()))
                .ReturnsAsync(new AccountDto() { Id = 2 });

            nbpService
                .Setup(x => x.ExchangePlnToEuro(It.IsAny<double>()))
                .ReturnsAsync(returnValue);

            _accountController
                = new AccountController(mockLogger.Object, accountService.Object, nbpService.Object);
        }

        [Test]
        public void TestResultOkObjectResult()
        {
            var result = _accountController.GetEuroSaldoAsync(2).Result;
            Assert.IsAssignableFrom<OkObjectResult>(result);
        }

        [Test]
        public void TestResultBadRequestResult()
        {
            _accountController.ModelState.AddModelError("Name", "Required");
            var result = _accountController.GetEuroSaldoAsync(2).Result;
            Assert.IsAssignableFrom<BadRequestObjectResult>(result);
        }


    }
}