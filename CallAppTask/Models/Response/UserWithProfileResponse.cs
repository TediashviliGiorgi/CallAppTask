namespace CallAppTask.Models.Response
{
    public class UserWithProfileResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
    }
}
