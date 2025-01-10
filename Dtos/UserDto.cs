using System.ComponentModel.DataAnnotations;

namespace AppointmentManagementAPI.Dtos
{
    public class UserDto
    {
        [Required(ErrorMessage = "The username field is required.")]
        [StringLength(50, ErrorMessage = "The username must be between 3 and 50 characters.", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password field is required.")]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
