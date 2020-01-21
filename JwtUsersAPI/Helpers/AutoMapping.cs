using System.Collections.Generic;
using AutoMapper;
using JwtUsersAPI.Entities;

namespace JwtUsersAPI.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserToReturn>();
        }
    }
}