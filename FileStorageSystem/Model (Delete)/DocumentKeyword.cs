using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageSystem.Model
{
    public class DocumentKeyword
    {
        [ForeignKey("Document")]
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        [ForeignKey("Keyword")]
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
