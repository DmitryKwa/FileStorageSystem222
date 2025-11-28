using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace FileStorageSystem.Model
{
    [Table("DocumentsType")]
    public class DocumentsType
    {
        [Key]
        public string Name { get; set; }
    }
}
