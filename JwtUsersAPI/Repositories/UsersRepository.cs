using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtUsersAPI.Data;
using JwtUsersAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtUsersAPI.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly UsersContext _context;

        public UsersRepository(UsersContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Add(User entity)
        {
            var user = await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<User> Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}