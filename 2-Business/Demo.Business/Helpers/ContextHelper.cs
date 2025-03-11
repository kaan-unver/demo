using Microsoft.AspNetCore.Http;
using Demo.Core.Utilities.Extensions;
using Demo.DTO.User;

namespace Demo.Business.Helper
{
    public abstract class ContextHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContextHelper(IHttpContextAccessor httpContextAccessor) =>
                _httpContextAccessor = httpContextAccessor;

        public UserDto? User => (UserDto)_httpContextAccessor?.HttpContext?.Items["User"];
        public string? MessageCode => _httpContextAccessor.HttpContext?.Items["MessageCodeForRequest"]?.ToString();
        public string? TransactionId => _httpContextAccessor.HttpContext?.Items["TransactionId"]?.ToString();
        public string? ScreenCode => _httpContextAccessor.HttpContext?.Items["ScreenCode"]?.ToString();
        public string? RequestUri => ($"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}");
        public string? RequestPath => _httpContextAccessor.HttpContext.Request.RouteValues.GetRequestedPath();
    }
}
