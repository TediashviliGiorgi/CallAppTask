using Azure.Core;
using CallAppTask.DB.Entities;
using CallAppTask.Interfaces.Irepository;
using CallAppTask.Interfaces.Iservice;
using CallAppTask.Models.Request;
using CallAppTask.Models.Response;
using Microsoft.Identity.Client;

namespace CallAppTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<UserResponse>> CreateUser(CreateUserRequest request)
        {
            var response = new BaseResponse<UserResponse>();
            var userExists = await _userRepository.UserExistsByEmail(request);

            if (userExists == false)
            {

                var newUser = new UserEntity
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email,
                    IsActive = request.IsActive,
                };

                await _userRepository.AddUserAsync(newUser);
                await _userRepository.SaveChangesAsync();

                var userResponse = new UserResponse
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    IsActive = request.IsActive,
                };

                response.IsSuccess = true;
                response.Message = "User Created Successfully";
                response.Data = userResponse;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "User Already Exists";
                response.Data = null;
            }

            return response;
        }

        public async Task<BaseResponse<UserResponse>> GetUserById(int userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            if (userEntity == null)
            {
                return new BaseResponse<UserResponse>
                {
                    IsSuccess = false,
                    Message = "User not found.",
                    Data = null
                };
            }

            var userResponse = new UserResponse
            {
                UserName = userEntity.UserName,
                Email = userEntity.Email,
                IsActive = userEntity.IsActive,
            };

            return new BaseResponse<UserResponse>
            {
                IsSuccess = true,
                Message = "User retrieved successfully.",
                Data = userResponse
            };
        }


        public async Task<BaseResponse<List<UserResponse>>> GetAllUsers()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();

            var userResponses = userEntities.Select(u => new UserResponse
            {
                UserName = u.UserName,
                Email = u.Email,
                IsActive = u.IsActive
            }).ToList();

            return new BaseResponse<List<UserResponse>>
            {
                IsSuccess = true,
                Message = "Users retrieved successfully.",
                Data = userResponses
            };
        }

        public async Task<BaseResponse<UserResponse>> UpdateUser(int userId, UpdateUserRequest request)
        {
            await _userRepository.UpdateUserAsync(userId, request);

            var updatedUserEntity = await _userRepository.GetUserByIdAsync(userId);

            if (updatedUserEntity == null)
            {
                return new BaseResponse<UserResponse>
                {
                    IsSuccess = false,
                    Message = "User not found."
                };
            }

            var userResponse = new UserResponse
            {
                UserName = updatedUserEntity.UserName,
                Email = updatedUserEntity.Email,
                IsActive = updatedUserEntity.IsActive
            };

            return new BaseResponse<UserResponse>
            {
                IsSuccess = true,
                Message = "User updated successfully.",
                Data = userResponse
            };
        }


        public async Task<BaseResponse<UserResponse>> DeleteUser(int userId)
        {
            var response = new BaseResponse<UserResponse>();
            var userEntity = await _userRepository.UserExistsById(userId);

            if (userEntity == null)
            {
                response.IsSuccess = false;
                response.Message = "User don't Exists";
                response.Data = null;
            }
            else
            {
                await _userRepository.DeleteUserAsync(userEntity);
                response.IsSuccess = true;
                response.Message = "User Deleted Successfully";
                response.Data = null;
            }

            return response;
        }
    }
}
