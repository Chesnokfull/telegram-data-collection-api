using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace API.Models
{
    [Keyless]
    public class User
    {
        [Required]
        public  int chat_id { get; set; }
        public string? brand_catalogue { get; set; }
        public string? sku_catalogue { get; set; }
        public string? status { get; set; }
        public DateTime last_activity { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public User(int chat_id, DateTime last_activity)
        {
            this.chat_id = chat_id;
            this.last_activity = last_activity;
            created_date = DateTime.Now;
            updated_date = DateTime.Now;
        }
    }
}
