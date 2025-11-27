using System.ComponentModel.DataAnnotations;

namespace FileStorageSystem.Model
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Навигационное свойство: одна роль может быть у многих пользователей
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
