using System.ComponentModel.DataAnnotations;

namespace CallAppTask.Models.Request
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "IsActive status must be specified.")]
        public bool IsActive { get; set; }
    }
}
