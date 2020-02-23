using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MikeGrayCodes.Authentication.Application.Users;
using MikeGrayCodes.BuildingBlocks.Application;
using System;
using System.Threading.Tasks;

namespace MikeGrayCodes.Authentication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRequestExecutor requestExecutor;

        public UserController(IRequestExecutor requestExecutor)
        {
            this.requestExecutor = requestExecutor ?? throw new ArgumentNullException(nameof(requestExecutor));
        }

        [AllowAnonymous]
        [HttpPost("")]
        public async Task<IActionResult> RegisterNewUser([FromBody]ApplicationUserPostModel request)
        {
            await requestExecutor.ExecuteCommandAsync(new CreateUserCommand(request.Login, request.Password,
                request.Email, request.FirstName, request.LastName));

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> RegisterNewUser2()
        {
            ApplicationUserPostModel request = new ApplicationUserPostModel();
            request.Login = "Mike";
            request.Password = "fgdfgdf";
            request.Email = "micgra.mg@gmail.com";
            request.FirstName = "Mike";
            request.LastName = "Gray";

            await requestExecutor.ExecuteCommandAsync(new CreateUserCommand(request.Login, request.Password,
                request.Email, request.FirstName, request.LastName));

            return Ok();
        }
    }
}
