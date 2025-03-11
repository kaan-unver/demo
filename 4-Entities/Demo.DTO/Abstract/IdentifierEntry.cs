using Demo.Core.Models;

namespace Demo.DTO.Abstract
{
    public class IdentifierEntry : IDto
    {
        public Guid Id { get; set; }
    }
}
