using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageSystem.Models
{
    [Table("CAgents")]
    public class CAgent
    {
        [Key]
        public string INN { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? IDDetails { get; set; }
        public string? DateRegistered { get; set; }
    }
}
