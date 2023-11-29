using System.ComponentModel.DataAnnotations;

namespace CallAppTask.Models.Request
{
    public class CreateUserProfileRequest
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Personal number must be exactly 11 characters long.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Personal number must consist of 11 digits.")]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }
    }
}
