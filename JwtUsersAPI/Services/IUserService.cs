using System.Collections.Generic;
using JwtUsersAPI.Entities;

namespace JwtUsersAPI.Services
{
    public interface IUserService
    {
        UserToReturn Authenticate(string username, string password);
        IEnumerable<UserToReturn> GetAll();
    }
}