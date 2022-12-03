using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness.Users
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        [Required]
        public string UserTypeName { get; set; } = string.Empty;
    }
}
