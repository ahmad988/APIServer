using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Questions
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int QuestionTypeID { get; set; }
        [Required]
        public string QuestionTitle { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
