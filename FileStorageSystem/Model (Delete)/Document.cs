using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FileStorageSystem.Model
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [StringLength(1000)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; }

        // Внешний ключ к Counterparty
        [ForeignKey("Sender")]
        public int SenderId { get; set; }
        public Counterparty Sender { get; set; }

        // Внешний ключ к DocumentType
        [ForeignKey("Type")]
        public int TypeId { get; set; }
        public DocumentType Type { get; set; }

        // Внешний ключ к Extension
        [ForeignKey("DocumentExtension")]
        public int ExtensionId { get; set; }
        public Extension DocumentExtension { get; set; }

        // Навигационное свойство для многих ко многим с Keywords
        public ICollection<DocumentKeyword> DocumentKeywords { get; set; } = new List<DocumentKeyword>();
    }
}
