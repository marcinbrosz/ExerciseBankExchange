using ExerciseBankExchange.Dtos;
using ExerciseBankExchange.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services.Interfaces
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccount(int id);
        IEnumerable<AccountDto> CreateLocalAccountTable();
    }
}
