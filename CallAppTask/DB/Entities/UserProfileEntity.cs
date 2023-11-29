using System.ComponentModel.DataAnnotations;

namespace CallAppTask.DB.Entities
{
    public class UserProfileEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }

        // Navigation property for the related UserEntity
        public virtual UserEntity User { get; set; }
    }
}
