using System.Collections.Generic;
using System.Threading.Tasks;
using JwtUsersAPI.Entities;

namespace JwtUsersAPI.Services
{
    public interface IUserService
    {
        UserToReturn Authenticate(string username, string password);
        Task<List<UserToReturn>> GetAll();
        Task<UserToReturn> Get(int id);
        Task<UserToReturn> Add(User entity);
        Task<bool> Update(User entity);
        Task<bool> Delete(int id);
    }
}