using ExerciseBankExchange.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> GetAccount(int id);
        IEnumerable<Account> CreateLocalAccountTable();
    }
}
