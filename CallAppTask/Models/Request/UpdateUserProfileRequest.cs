using System.ComponentModel.DataAnnotations;

namespace CallAppTask.Models.Request
{
    public class UpdateUserProfileRequest
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; }
    }
}
