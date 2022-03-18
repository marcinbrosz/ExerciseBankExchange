using ExerciseBankExchange.Entities.DbContextss;
using ExerciseBankExchange.Entities.Models;
using ExerciseBankExchange.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Services
{
    public class AccountService: IAccountService
    {
        private readonly AccountContext _accountContext;

        public AccountService(AccountContext accountContext)
        {
            _accountContext = accountContext;
        }
        public async Task<Account> GetAccount(int id)
            => await _accountContext.Accounts
            .Include(c=>c.User)
            .SingleOrDefaultAsync(x => x.UserId == id);

        public IEnumerable<Account> CreateLocalAccountTable()
        {
            return new List<Account>() { 
                new Account() { Id=1, User = new User() { Id=1, Name = "John" } },
                new Account() { Id=2, User = new User() { Id=2, Name = "Eryk" } }, 
                new Account() { Id=3, User = new User() { Id=2, Name = "Martin" } } 
            };
        }
    }
}
