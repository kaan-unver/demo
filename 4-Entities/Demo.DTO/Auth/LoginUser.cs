using Demo.Core.Models;

namespace Demo.DTO.Auth
{
    public class LoginUser:IDto
    {
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
