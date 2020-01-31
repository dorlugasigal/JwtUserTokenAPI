using JwtUsersAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtUsersAPI.Data
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}