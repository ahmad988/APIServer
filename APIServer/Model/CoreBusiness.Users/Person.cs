using System.ComponentModel.DataAnnotations;

namespace APIServer.Model.CoreBusiness.Users
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime Birthday { get; set; }

        public double Phone { get; set; }
        public bool Gender { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}
