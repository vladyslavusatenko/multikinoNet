using System.ComponentModel.DataAnnotations;

namespace MultikinoUserWeb.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Haslo { get; set; }
    }
}