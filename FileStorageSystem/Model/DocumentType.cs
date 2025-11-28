using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FileStorageSystem.Model
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Навигационное свойство: один тип может быть у многих документов
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
