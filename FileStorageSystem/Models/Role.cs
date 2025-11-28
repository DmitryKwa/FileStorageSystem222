using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageSystem.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}
