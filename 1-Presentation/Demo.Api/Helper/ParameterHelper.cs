using Demo.Business.Abstract.Messages;
using Demo.Business.Exceptions;
using Demo.Core.Constants;
using Demo.Core.Utilities.Extensions;

namespace Demo.Api.Helpers
{
    public static class ParameterHelper
    {
        public static T GetFromHeader<T>(HttpContext _httpContext, IMessageManager _messageManager, string key, bool isNecessary = true, bool fireException = true) where T : IParsable<T>
        {
            string data = _httpContext.Request.Headers.SingleOrDefault(x => x.Key == key).Value!.FirstOrDefault();
            if (data == null)
            {
                if (isNecessary && fireException)
                    throw new BadRequestException(MessageCodes.MissingParameter);
                return default(T);
            }

            return data.Parse<T>();
        }
        public static string GetRequestedEndpoint(HttpContext _httpContext, IMessageManager _messageManager)
        {
            string controllerName = _httpContext.Request.RouteValues["controller"].ToString();
            string actionName = _httpContext.Request.RouteValues["action"].ToString();
            if (controllerName == null || actionName == null)
            {
                throw new BadRequestException(MessageCodes.MissingRouteValues);
            }

            return $"/api/{controllerName}/{actionName}";
        }
    }
}
