using CallAppTask.DB.Entities;
using CallAppTask.Interfaces.Irepository;
using CallAppTask.Interfaces.Iservice;
using CallAppTask.Models.Request;
using CallAppTask.Models.Response;
using CallAppTask.Repositories;

namespace CallAppTask.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileService(IUserProfileRepository userProfileRepository)
        {

            _userProfileRepository = userProfileRepository;

        }
        public async Task <BaseResponse<UserProfileResponse>> CreateUserProfile(CreateUserProfileRequest request)
        {
            var response = new BaseResponse<UserProfileResponse>();
            var userProfileExists = await _userProfileRepository.UserProfileExists(request.PersonalNumber);

            if(userProfileExists == false)
            {
                var newUserProfile = new UserProfileEntity()
                {
                    FirstName = request.FirstName,
                    UserId = request.UserId,
                    LastName = request.LastName,
                    PersonalNumber = request.PersonalNumber,
                };

                await _userProfileRepository.AddUserProfileAsync(newUserProfile);
                await _userProfileRepository.SaveChangesAsync();

                var userProfileResponse = new UserProfileResponse()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PersonalNumber = request.PersonalNumber,
                };
                response.IsSuccess = true;
                response.Message = "User Profile Created Successfully";
                response.Data = userProfileResponse;
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "User Profile Already Exists";
                response.Data = null;
            }
            return response;
        }
        public async Task<BaseResponse<UserProfileResponse>> GetUserProfile(int id)
        {
            var userProfileEntity = await _userProfileRepository.GetUserProfileAsync(id);
            if (userProfileEntity == null)
            {
                return new BaseResponse<UserProfileResponse>
                {
                    IsSuccess = false,
                    Message = "User profile not found.",
                    Data = null
                };
            }

            var userProfileResponse = new UserProfileResponse
            {
                FirstName = userProfileEntity.FirstName,
                LastName = userProfileEntity.LastName,
                PersonalNumber = userProfileEntity.PersonalNumber
            };

            return new BaseResponse<UserProfileResponse>
            {
                IsSuccess = true,
                Message = "User profile retrieved successfully.",
                Data = userProfileResponse
            };
        }
        public async Task<BaseResponse<UserProfileResponse>> UpdateUserProfile(int id, UpdateUserProfileRequest request)
        {
            var userProfileToUpdate = new UserProfileEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var updateSuccess = await _userProfileRepository.UpdateUserProfileAsync(userProfileToUpdate);
            if (!updateSuccess)
            {
                return new BaseResponse<UserProfileResponse>
                {
                    IsSuccess = false,
                    Message = "Update failed. User profile not found."
                };
            }

            var updatedUserProfileResponse = new UserProfileResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            return new BaseResponse<UserProfileResponse>
            {
                IsSuccess = true,
                Message = "User profile updated successfully.",
                Data = updatedUserProfileResponse
            };
        }


        public async Task<BaseResponse<object>> DeleteUserProfile(int id)
        {
            var userProfile = await _userProfileRepository.GetUserProfileAsync(id);
            if (userProfile != null)
            {
                await _userProfileRepository.DeleteUserProfileAsync(id);
                return new BaseResponse<object>
                {
                    IsSuccess = true,
                    Message = "User profile deleted successfully."
                };
            }
            else
            {
                return new BaseResponse<object>
                {
                    IsSuccess = false,
                    Message = "User profile not found."
                };
            }
        }
    }
}
