using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Source
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int user_chat_id { get; set; }
        [Required]
        public string source_id { get; set; }
        [Required]
        public string source { get; set; }
        public DateTime created_date { get; set; }
        public Source(int user_chat_id, string source_id, string source)
        {
            this.user_chat_id = user_chat_id;
            this.source_id = source_id;
            this.source = source;
            this.created_date = DateTime.Now;
        }
    }
}
