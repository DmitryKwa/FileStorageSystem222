using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FileStorageSystem.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public string Email { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string? Patronymic { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
