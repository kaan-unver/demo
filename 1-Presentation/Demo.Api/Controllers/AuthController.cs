using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Demo.DTO.User;
using Demo.Business.Abstract.UserManager;
using Demo.DTO.Auth;

namespace Demo.Api.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ActionName("login")]
        public IActionResult Login([FromBody] LoginUser dto)
        {
            var response = _authManager.GetUserByLogin(dto);
            //if (response != null && response.Success)
            //{
            //    response.Data.UserId = Guid.Empty;
            //}
            return CreateActionResult(response);
        }
        
        [HttpPost("[action]")]
        [ActionName("logout")]
        public IActionResult Logout()
        {
            //var response = _authManager.GetUserInfo(dto);
            //return CreateActionResult(response);

            return null;
        }
    }
}
