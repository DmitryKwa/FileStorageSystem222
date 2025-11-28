using System.ComponentModel.DataAnnotations;

namespace FileStorageSystem.Model
{
    public class Keyword
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Word { get; set; }

        // Навигационное свойство: многие ко многим через DocumentKeywords
        public ICollection<DocumentKeyword> DocumentKeywords { get; set; } = new List<DocumentKeyword>();
    }
}
