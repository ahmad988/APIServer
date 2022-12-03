using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        public int? CategoryID { get; set; }
        [Required]
        public string ProjectName { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public double Phone { get; set; }
        [Required]
        public string EmailAddress { get; set; } = string.Empty;

        public string Website { get; set; } = string.Empty;
        //navigation property for EF Core
        public Category Category { get; set; }

    }
}
