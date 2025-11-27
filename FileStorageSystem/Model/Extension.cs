using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FileStorageSystem.Model
{
    public class Extension
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)] // Расширение файла, например .pdf
        public string Name { get; set; }

        // Навигационное свойство: одно расширение может быть у многих документов
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
