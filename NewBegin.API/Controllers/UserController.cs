using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewBegin.Data.AuxiliaryModels;
using NewBegin.Data.Models;
using NewBegin.Services.Intefaces;

namespace NewBegin.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserService userService;
        public UserController(
            ILogger<UserController> logger,
            IUserService userService) 
        {
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserById()
        {
            var user = new UserModel()
            {
                Name = "test",
                Id = "111"
            };
            return Ok(user);

        }
        [HttpGet("{name}")]
        public IActionResult GetUserByName(string name)
        {
            var user = new UserModel()
            {
                Name = "name",
                Id = "222"
            };
            return Ok(user);

        }
        [HttpPost]
        public async Task<IActionResult> PostUser(UserRegistrationModel user)
        {
            var result = await userService.UserRegistration(user);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
