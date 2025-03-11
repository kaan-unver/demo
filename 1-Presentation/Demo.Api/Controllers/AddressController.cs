using Microsoft.AspNetCore.Mvc;
using Demo.Api.Helpers;
using Demo.Business.Abstract.Address;
using Demo.Business.Abstract.Messages;

namespace Demo.Api.Controllers
{
    public class AddressController : CustomBaseController
    {
        private readonly IAddressManager _addressManager;
        private readonly IMessageManager _messageManager;
        public AddressController(IAddressManager addressManager, IMessageManager messageManager)
        {
            _addressManager = addressManager;
            _messageManager = messageManager;
        }

        [HttpGet("[action]")]
        [ActionName("cities")]
        public IActionResult GetCities()
        {
            var response = _addressManager.GetCities();
            return CreateActionResult(response);
        }
        [HttpGet("[action]")]
        [ActionName("getCountiesByCity")]
        public IActionResult GetCountiesByCity(int city)
        {
            var response = _addressManager.GetCountiesByCity(city);
            return CreateActionResult(response);
        }
        [HttpGet("[action]")]
        [ActionName("getCounties")]
        public IActionResult GetCounties()
        {
            var response = _addressManager.GetCounties();
            return CreateActionResult(response);
        }
        [HttpGet("[action]")]
        [ActionName("getHometownsByCounty")]
        public IActionResult GetHometownsByCounty()
        {
            var countyId = ParameterHelper.GetFromHeader<int>(HttpContext, _messageManager, "countyid");
            var response = _addressManager.GetHometownByCounty(countyId);
            return CreateActionResult(response);
        }
        [HttpGet("[action]")]
        [ActionName("getHometowns")]
        public IActionResult GetHometowns()
        {
            var response = _addressManager.GetHometowns();
            return CreateActionResult(response);
        }
    }
}
