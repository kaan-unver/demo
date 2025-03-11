using Demo.Business.Abstract.Messages;
using Demo.Business.Exceptions;
using Demo.Core.Constants;

namespace Demo.Api.Middlewares
{
    public class HttpMethodValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpMethodValidationMiddleware(RequestDelegate next)
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

            if (context.GetEndpoint().DisplayName.Contains(Constants.MethodNotAllowed.ToString()))
                throw new ClientSideException(MessageCodes.MethodNotAllowedError);

            await _next(context);

            if (context.Response.StatusCode == Constants.UnsupportedMediaType)
                throw new ClientSideException(MessageCodes.UnsupportedMediaTypeError);

            else if (context.Response.StatusCode == Constants.MethodNotAllowed)
                throw new ClientSideException(MessageCodes.MethodNotAllowedError);

        }
    }
}
