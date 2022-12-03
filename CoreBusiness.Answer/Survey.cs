using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Answer
{
    public class Survey
    {
        [Key]
        public int SurveyID { get; set; }
        public DateTime SurveyDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
