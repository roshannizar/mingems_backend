using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Users;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using Mingems.Shared.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseApiController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService, IMapper mapper) : base(mapper)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            var user = await userService.Authenticate(model.Email, model.Password);
            return new JsonResult(new { message = user }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var user = await userService.GetAllAsync();
            var userMapped = mapper.Map<IEnumerable<UserDto>>(user);
            return Ok(userMapped);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            await userService.CreateAsync(user);
            return new JsonResult(new { message = "Account created successfully, Please verify your account!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize]
        [HttpGet("metadata")]
        public async Task<ActionResult<UserDto>> MetaData()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = await userService.GetMetaDataAsync(token);
            return Ok(mapper.Map<UserDto>(user));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UserDto>> Update(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);
            await userService.UpdateAsync(user);
            return new JsonResult(new { message = "Account updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpGet("verify")]
        public async Task<ActionResult> VerfiyAccount(string code)
        {
            await userService.VerifyAccountAsync(code);
            return new JsonResult(new { message = "Account verified successfully!" }) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost("forgotpassword")]
        public async Task<ActionResult> ForgotPassword(EmailModel emailModel)
        {
            await userService.ForgotPasswordAsync(emailModel.Email);
            return new JsonResult(new { message = "Reset password link has been sent to your email!" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize]
        [HttpPut("updatepassword")]
        public async Task<ActionResult> UpdatePassword(PasswordModel responseDto)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            await userService.UpdatePasswordAsync(responseDto, token);
            return new JsonResult(new { message = "Password reset was successfull!" }) { StatusCode = StatusCodes.Status200OK };
        }
    }
}
