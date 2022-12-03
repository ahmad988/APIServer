using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Answer
{
    public class CollectAnswer
    {
        [Key]
        public int CollectAnswerID { get; set; }


        public int UserID { get; set; }

        public int ProjectID { get; set; }

        public int QuestionID { get; set; }

        public int AnswerID { get; set; }
        public string AnswerText { get; set; } = string.Empty;
        public int SurveyID { get; set; }
    }
}
