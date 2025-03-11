using Microsoft.AspNetCore.Mvc;
using Demo.Core.Utilities.Results;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(IDataResult<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
        [NonAction]
        public IActionResult CreateActionResult(Demo.Core.Utilities.Results.IResult response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };


        }
    }
}
