using System.Collections.Generic;
using System.Threading.Tasks;
using JwtUsersAPI.Entities;

namespace JwtUsersAPI.Services
{
    /// <summary>
    /// User Service interface for basic methods
    /// </summary>
    public interface IUserService
    {
        UserToReturn Authenticate(string username, string password);
        Task<List<UserToReturn>> GetAll();
        Task<UserToReturn> Get(int id);
        Task<UserToReturn> Add(User entity);
        Task<bool> Update(User entity);
        Task<UserToReturn> Delete(int id);
        Task<bool> UserExists(int id);
    }
}