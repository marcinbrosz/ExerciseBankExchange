using ExerciseBankExchange.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services.Interfaces
{
    public interface IExchanger
    {
        public Task<decimal> ExchangePlnToEuro(double saldePln);
    }
}
