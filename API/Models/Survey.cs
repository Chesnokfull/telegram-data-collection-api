using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Survey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public int user_chat_id { get; set; }
        public string survey { get; set; }
        public string question {  get; set; }
        public string answer { get; set; }
        public string? comment { get; set; }
        public DateTime created_date { get; set; }
        public Survey(int user_chat_id, string survey, string question, string answer, string comment)
        {
            this.user_chat_id = user_chat_id;
            this.survey = survey;
            this.question = question;
            this.answer = answer;
            this.comment = comment;
            this.created_date = DateTime.Now;
        }
    }
}
