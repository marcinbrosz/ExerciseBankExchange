using AutoMapper;
using ExerciseBankExchange.Dtos;
using ExerciseBankExchange.Entities.Models;
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
