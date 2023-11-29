using CallAppTask.DB.Entities;

namespace CallAppTask.Interfaces.Irepository
{
    public interface IUserProfileRepository
    {
        public Task AddUserProfileAsync(UserProfileEntity userProfileEntity);
        public Task<UserProfileEntity> GetUserProfileAsync(int id);
        public Task<bool> UpdateUserProfileAsync(UserProfileEntity userProfile);
        public Task DeleteUserProfileAsync(int id);
        public Task<bool> UserProfileExists(string persponalNumber);
        public Task SaveChangesAsync();
    }
}
