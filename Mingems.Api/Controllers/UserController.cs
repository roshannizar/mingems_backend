using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Core.Services;
using Mingems.Shared.Core.Helpers;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
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
    }
}
