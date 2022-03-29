using AutoMapper;
using ExerciseBankExchange.Models;
using ExerciseBankExchange.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseBankExchange.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<User, UserDto>();
        }
    }
}
