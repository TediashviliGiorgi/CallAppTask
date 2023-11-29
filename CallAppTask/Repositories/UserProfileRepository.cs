using CallAppTask.DB;
using CallAppTask.DB.Entities;
using CallAppTask.Interfaces.Irepository;
using CallAppTask.Models.Request;
using CallAppTask.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace CallAppTask.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _db;
        public UserProfileRepository(AppDbContext db)
        {

            _db = db;

        }

        public async Task AddUserProfileAsync(UserProfileEntity userProfileEntity)
        {
            if (userProfileEntity != null)
            {
                await _db.UserProfiles.AddAsync(userProfileEntity);
            }
        }
        public async Task<UserProfileEntity> GetUserProfileAsync(int id)
        {
            return await _db.UserProfiles.FindAsync(id);
        }

        public async Task<bool> UpdateUserProfileAsync(UserProfileEntity userProfile)
        {
            var existingProfile = await _db.UserProfiles.FindAsync(userProfile.Id);
            if (existingProfile != null)
            {
                existingProfile.FirstName = userProfile.FirstName;
                existingProfile.LastName = userProfile.LastName;
                existingProfile.PersonalNumber = userProfile.PersonalNumber;

                await _db.SaveChangesAsync();
                return true; 
            }

            return false; 
        }

        public async Task DeleteUserProfileAsync(int id)
        {
            var userProfile = await _db.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _db.UserProfiles.Remove(userProfile);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> UserProfileExists(string persponalNumber)
        {
            return await _db.UserProfiles.AnyAsync(a => a.PersonalNumber == persponalNumber);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
