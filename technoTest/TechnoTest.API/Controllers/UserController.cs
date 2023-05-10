using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using technoTest.API.Models.User.Request;
using technoTest.API.Models.User.Response;
using TechnoTest.API.Validation;
using TechnoTest.BLL.Interfaces;
using TechnoTest.BLL.Models;

namespace TechnoTest.API.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;
        private readonly UserValidator _userValidator;

        public UserController(IMapper mapper, IUserManager userManager, UserValidator userValidator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userValidator = userValidator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var listUsers = await _userManager.GetAllUsersAsync();
                var result = _mapper.Map<IEnumerable<UserResponseDto>>(listUsers);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserAddRequestDto userAdd)
        {
            try
            {
                var validationResult = _userValidator.Validate(userAdd);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var user = _mapper.Map<User>(userAdd);
                var callback = await _userManager.CreateUserAsync(user);
                var result = _mapper.Map<UserResponseDto>(callback);


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int Id)
        {
            try
            {
                var callback = await _userManager.DeleteUserAsync(Id);
                var result = _mapper.Map<UserResponseDto>(callback);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int Id)
        {
            try
            {
                var user = await _userManager.GetUserByIdAsync(Id);
                var result = _mapper.Map<UserResponseDto>(user);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
