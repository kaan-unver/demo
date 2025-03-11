using Demo.Core.Models;

namespace Demo.DTO.JWT
{
    public class JWTDto:IDto
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
