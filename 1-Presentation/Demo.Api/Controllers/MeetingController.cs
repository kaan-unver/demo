using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Api.Helpers;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.User;
using Demo.DTO.Abstract;
using Demo.DTO.User;
using Demo.Business.Abstract.Meeting;
using Demo.DTO.Meeting;
using Microsoft.AspNetCore.Identity;

namespace Demo.Api.Controllers
{

    public class MeetingController : CustomBaseController
    {
        private readonly IMessageManager _messageManager;
        private readonly IMeetingManager _meetingManager;
        public MeetingController(IMeetingManager meetingManager, IMessageManager messageManager)
        {
            _meetingManager = meetingManager;
            _messageManager = messageManager;

        }
        [HttpGet("[action]")]
        [ActionName("getAll")]
        public IActionResult GetAll()
        {
            var response = _meetingManager.GetAll();
            return CreateActionResult(response);
        }
        [HttpPost("[action]")]
        [ActionName("add")]
        public IActionResult Add([FromForm] InsertMeetingDto dto)
        {
            var response = _meetingManager.Add(dto);
            return CreateActionResult(response);
        }
        [HttpPut("[action]")]
        [ActionName("delete")]
        public IActionResult Delete([FromBody]Guid id)
        {
            //var id = ParameterHelper.GetFromHeader<Guid>(HttpContext, _messageManager, "id");
            var response = _meetingManager.Delete(id);
            return CreateActionResult(response);
        }
    }
}
