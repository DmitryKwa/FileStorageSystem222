using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FileStorageSystem.Models
{
    [Table("DocumentsType")]
    public class DocumentType
    {
        [Key]
        public string Name { get; set; }
    }
}
