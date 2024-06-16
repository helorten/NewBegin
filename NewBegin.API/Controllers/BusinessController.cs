using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewBegin.Data.AuxiliaryModels;
using NewBegin.Services.Intefaces;

namespace NewBegin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController: ControllerBase
    {
        private readonly IBusinessService businessService;
        private readonly ILogger<BusinessController> logger;
        public BusinessController(
            IBusinessService businessService,
            ILogger<BusinessController> logger
            ) 
        {
            this.businessService = businessService;
            this.logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBusinessController(NewBusinessRegistrationModel newBusinessRegistrationModel)
        {
            var result = await businessService.AddNewBusiness(newBusinessRegistrationModel);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
