using System.ComponentModel.DataAnnotations;

namespace JwtUsersAPI.Entities
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}