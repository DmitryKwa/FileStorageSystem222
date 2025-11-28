using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FileStorageSystem.Model
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DocType { get; set; }
        public long Size { get; set; }
        public DateTime AddTime { get; set; }
        public string? INNCAgents { get; set; }
        public string FilePath { get; set; }
    }
}
