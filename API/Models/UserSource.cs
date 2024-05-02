using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserSource
    {
        public int chat_id { get; set; }
        public DateTime last_activity { get; set; }
        [Required]
        public int user_chat_id { get; set; }
        [Required]
        public string source_id { get; set; }
        [Required]
        public string source { get; set; }

    }
}
