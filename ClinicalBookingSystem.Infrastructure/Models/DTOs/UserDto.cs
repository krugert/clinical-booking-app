using System.ComponentModel.DataAnnotations;

namespace ClinicalBookingSystem.Infrastructure.Models.DTOs
{
    public class UserDto
    {
        [Required(ErrorMessage = "The username is required.")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "The password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
