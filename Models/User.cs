using System.ComponentModel.DataAnnotations;

namespace Parking_App.Models
{
    public class User : Entity
    {
        public long? Id { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(3, ErrorMessage = "Password must be greater than two characters")]
        public string? Password { get; set; }

        public string? ProfileName { get; set; }
    }
}