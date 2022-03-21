using AutoMapper;
using ExerciseBankExchange.Dtos;
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
        private readonly IMapper _mapper;

        public AccountService(AccountContext accountContext, IMapper mapper)
        {
            _accountContext = accountContext;
            _mapper = mapper;
        }
        public async Task<AccountDto> GetAccount(int id)
        {
            var account = await _accountContext.Accounts
              .Include(c => c.User)
              .SingleOrDefaultAsync(x => x.UserId == id);
            return _mapper.Map<Account, AccountDto>(account);
        }

        public IEnumerable<AccountDto> CreateLocalAccountTable()
        {
            return new List<AccountDto>() { 
                new AccountDto() { Id=1, User = new UserDto() { Id=1, Name = "John" }, SaldoPl=100 },
                new AccountDto() { Id=2, User = new UserDto() { Id=2, Name = "Eryk" }, SaldoPl=500 }, 
                new AccountDto() { Id=3, User = new UserDto() { Id=2, Name = "Martin" }, SaldoPl=1000 } 
            };
        }
    }
}
