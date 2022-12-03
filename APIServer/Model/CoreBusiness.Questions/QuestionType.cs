using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness.Questions
{
    public class QuestionType
    {
        [Key]
        public int QuestionTypeId { get; set; }
        [Required]
        public string QuestionName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
