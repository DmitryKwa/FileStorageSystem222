using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FileStorageSystem.Model
{
    public class Counterparty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)] // ИНН обычно 10-12 символов
        public string Inn { get; set; }

        // Навигационное свойство: один контрагент может быть отправителем многих документов
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
