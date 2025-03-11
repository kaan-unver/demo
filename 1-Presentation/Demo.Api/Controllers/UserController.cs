using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Api.Helpers;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.User;
using Demo.DTO.Abstract;
using Demo.DTO.User;

namespace Demo.Api.Controllers
{

    public class UserController : CustomBaseController
    {
        private readonly IMessageManager _messageManager;
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager, IMessageManager messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        
        }
        [HttpPost("[action]")]
        [ActionName("add")]
        public IActionResult Add([FromForm] InsertTUserDto dto)
        {
            var response = _userManager.Add(dto);
            return CreateActionResult(response);
        }
    }
}
