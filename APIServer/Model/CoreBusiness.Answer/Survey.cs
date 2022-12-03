using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness.Answer
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
