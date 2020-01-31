using System.Collections.Generic;
using System.Threading.Tasks;
using JwtUsersAPI.Entities;

namespace JwtUsersAPI.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}