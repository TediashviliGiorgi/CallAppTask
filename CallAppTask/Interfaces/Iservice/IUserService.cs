using CallAppTask.Models.Request;
using CallAppTask.Models.Response;

namespace CallAppTask.Interfaces.Iservice
{
    public interface IUserService
    {
        public Task<BaseResponse<UserResponse>> CreateUser(CreateUserRequest request);
        public Task<BaseResponse<UserResponse>> GetUserById(int userId);
        public Task<BaseResponse<List<UserResponse>>> GetAllUsers();
        public Task<BaseResponse<UserResponse>> UpdateUser(int userId, UpdateUserRequest request);
        public Task<BaseResponse<UserResponse>> DeleteUser(int userId);

    }
}
