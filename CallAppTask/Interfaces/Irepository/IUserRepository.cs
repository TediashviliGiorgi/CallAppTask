using CallAppTask.DB.Entities;
using CallAppTask.Models.Request;

namespace CallAppTask.Interfaces.Irepository
{
    public interface IUserRepository
    {
        public Task AddUserAsync(UserEntity userEntity);
        public Task<UserEntity> UserExistsById(int userId);
        public Task<UserEntity> GetUserByIdAsync(int userId);
        public Task<List<UserEntity>> GetAllUsersAsync();
        public Task UpdateUserAsync(int userId, UpdateUserRequest request);
        public Task DeleteUserAsync(UserEntity userEntity);
        public Task<bool> UserExistsByEmail(CreateUserRequest userRequest);
        public Task SaveChangesAsync();
        
    }
}
