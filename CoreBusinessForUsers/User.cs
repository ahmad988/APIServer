using System.ComponentModel.DataAnnotations;

namespace CoreBusinessForUsers
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]

        public int PersonID { get; set; }
        [Required]

        public int UserTypeID { get; set; }
        [Required(ErrorMessage = "Please Enter a UserName")]

        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please Enter a Password")]
        public string Password { get; set; } = string.Empty;

    }
}
