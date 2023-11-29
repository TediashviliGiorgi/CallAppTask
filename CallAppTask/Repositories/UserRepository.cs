using CallAppTask.DB.Entities;
using CallAppTask.DB;
using CallAppTask.Interfaces.Irepository;
using Microsoft.EntityFrameworkCore;
using CallAppTask.Models.Request;
using CallAppTask.Models.Response;

namespace CallAppTask.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddUserAsync(UserEntity userEntity)
        {
            if (userEntity != null)
            {
                await _db.Users.AddAsync(userEntity);
            }
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId)
        {
            var user =  await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async Task<List<UserEntity>> GetAllUsersAsync()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }

        public async Task UpdateUserAsync(int userId, UpdateUserRequest request)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.IsActive = request.IsActive;

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(UserEntity userEntity)
        {
            var userProfile = await _db.UserProfiles.FirstOrDefaultAsync(up => up.UserId == userEntity.Id);
            if (userProfile != null)
            {
                _db.UserProfiles.Remove(userProfile);
            }

            _db.Users.Remove(userEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<UserEntity> UserExistsById(int userId)
        {
            var userEntity = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return userEntity;
        }



        public async Task<bool> UserExistsByEmail(CreateUserRequest userRequest)
        {
            return await _db.Users.AnyAsync(a => a.Email == userRequest.Email);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
