using Demo.Core.Models;

namespace Demo.DTO.Address
{
    public class AddressDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
