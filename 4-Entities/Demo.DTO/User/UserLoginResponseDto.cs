
namespace Demo.DTO.User
{
    public class UserLoginResponseDto
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Guid UserId { get; set; }

    }
}
