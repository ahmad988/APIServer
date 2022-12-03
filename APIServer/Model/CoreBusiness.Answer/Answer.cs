using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness.Answer
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }
        [Required]
        public int QuestionID { get; set; }

        public string Text { get; set; } = string.Empty;
    }
}
