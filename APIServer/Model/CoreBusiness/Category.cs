using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
