using ExerciseBankExchange.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services.Interfaces
{
    public interface INbpService
    {
        public Task<NbpTable> GetNbpEuroRate();
        public Task<double> ExchangePlnToEuro(double saldePln);
    }
}
