using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageSystem.Model
{
    [Table("Details")]
    public class Details
    {
        [Key]
        public int ID { get; set; }
        public string? LegalAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}
