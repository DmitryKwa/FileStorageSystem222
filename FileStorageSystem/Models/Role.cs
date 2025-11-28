using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageSystem.Model
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public string Name { get; set; }
    }
}
