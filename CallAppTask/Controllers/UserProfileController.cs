using Azure.Core;
using CallAppTask.Interfaces.Iservice;
using CallAppTask.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CallAppTask.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [Authorize]
        [HttpPost("create-user-profile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateUserProfileRequest request)
        {
            var newUserProfile = await _userProfileService.CreateUserProfile(request);
            return Ok(newUserProfile);
        }

        [Authorize]
        [HttpGet("get-userProfile-by-id")]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            var result = await _userProfileService.GetUserProfile(id);
            if (!result.IsSuccess)
            {
                return NotFound(result.Message); 
            }
            return Ok(result);
        }

        [Authorize]
        [HttpPost("update-user-profile")]
        public async Task<IActionResult> UpdateUserProfile(int id, [FromBody] UpdateUserProfileRequest request)
        {
            var result = await _userProfileService.UpdateUserProfile(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [Authorize]
        [HttpDelete("delete-user-profile")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var result = await _userProfileService.DeleteUserProfile(id);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            else
            {
                return NotFound(result.Message);
            }
        }
    }
}
