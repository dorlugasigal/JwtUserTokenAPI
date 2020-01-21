using System.ComponentModel.DataAnnotations;

namespace JwtUsersAPI.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}