using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtUsersAPI.Data;
using JwtUsersAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JwtUsersAPI.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly UsersContext _context;
        private readonly ILogger _logger;

        public UsersRepository()
        {
            //UsersContext context,
            _context = null;
            //_logger = logger;
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (System.Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                return null;
            }
        }

        public async Task<User> Get(int id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (System.Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                return null;
            }
        }

        public async Task<User> Add(User entity)
        {
            try
            {
                var user = await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync();
                return user.Entity;
            }
            catch (System.Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                return null;
            }
        }

        public async Task<bool> Update(User entity)
        {
            try
            {
                var user = await _context.Users.FindAsync(entity.Id);
                if (user == null)
                {
                    return false;
                }
                _context.Entry(entity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false;
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception ex)
            {
                //_logger.Log(LogLevel.Error, ex, ex.Message);
                return false;
            }
        }
    }
}