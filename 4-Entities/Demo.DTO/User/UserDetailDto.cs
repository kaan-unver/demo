using Demo.Core.Models;

namespace Demo.DTO.User
{
    public class UserDetailDto : IDto
    {
        public Guid Id { get; set; }


        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
