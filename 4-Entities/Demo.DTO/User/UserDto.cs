using Demo.Core.Models;

namespace Demo.DTO.User
{
    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public string Langu { get; set; }

    }
}
