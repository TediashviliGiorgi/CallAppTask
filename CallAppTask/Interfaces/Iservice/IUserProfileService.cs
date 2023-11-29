using CallAppTask.Models.Request;
using CallAppTask.Models.Response;

namespace CallAppTask.Interfaces.Iservice
{
    public interface IUserProfileService
    {
        public Task<BaseResponse<UserProfileResponse>> CreateUserProfile(CreateUserProfileRequest request);
        public Task<BaseResponse<UserProfileResponse>> GetUserProfile(int id);
        public Task<BaseResponse<UserProfileResponse>> UpdateUserProfile(int id, UpdateUserProfileRequest request);
        public Task<BaseResponse<object>> DeleteUserProfile(int id);
    }
}
