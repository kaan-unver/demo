using Demo.Api.Helpers;
using Demo.Business.Abstract.Messages;
using Demo.Business.Exceptions;
using Demo.Core.Constants;

namespace Demo.Api.Middlewares
{
    public class EndpointMiddleware
    {
        private readonly RequestDelegate _next;

        public EndpointMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMessageManager messageManager)
        {
            if (!context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            var endPoint = ParameterHelper.GetRequestedEndpoint(context, messageManager);
            //var IPAddress = context.Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4()?.ToString();
            context.Items["TokenType"] = endPoint == Constants.LoginEndpoint || endPoint == Constants.SignUp ? Constants.TokenAnonymous : Constants.TokenJW;
            await _next(context);
            return;

        }
    }
}
