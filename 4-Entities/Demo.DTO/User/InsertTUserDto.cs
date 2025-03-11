using Demo.Core.Models;
using Microsoft.AspNetCore.Http;
namespace Demo.DTO.User
{
    public class InsertTUserDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
