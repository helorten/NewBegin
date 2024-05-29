using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewBegin.Data.Models;

namespace NewBegin.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(ILogger<UserController> logger) 
        {
            logger.LogInformation("UserController Init");
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

    }
}
