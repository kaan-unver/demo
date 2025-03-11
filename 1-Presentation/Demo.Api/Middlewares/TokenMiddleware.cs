
using Demo.Business.Abstract.JWT;
using Demo.Business.Abstract.User;
using Demo.Business.Abstract.UserManager;
using Demo.Business.Exceptions;

namespace Demo.Api.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IJWTManager jwtUtils, IAuthManager authManager)
        {
            if (!context.Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            if (context.Items["TokenType"]!.ToString() == Core.Constants.Constants.TokenAnonymous)
            {
                await _next(context);
                return;
            }

            if (context.Items["TokenType"]!.ToString() == Core.Constants.Constants.TokenJW)
            {
                JWTOperations(context, jwtUtils, authManager);
                await _next(context);
                return;
            }
            await _next(context);
        }
        private static void JWTOperations(HttpContext context, IJWTManager jwtUtils, IAuthManager authManager)
        {
            var token = context.Request.Headers["X-Authorization"].FirstOrDefault();
            var response = jwtUtils.GetUserGuidFromValidatedToken(token);
            if (response.Success)
            {
                var userResponse = authManager.GetUserByUserId(response.Data, context.Items["TokenType"]?.ToString());
                if (userResponse.Success)
                    context.Items["User"] = userResponse.Data;
                else
                {
                    context.Items["MessageCodeForRequest"] = userResponse.Code;
                    throw new UnAuthorizedException(userResponse.Messages.First());
                }
            }
            else
            {
                context.Items["MessageCodeForRequest"] = response.Code;
                throw new UnAuthorizedException(response.Messages.First());
            }
        }
    }
}
