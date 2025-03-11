using Demo.Core.Models;

namespace Demo.DTO.User
{
    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public Guid? TenantId { get; set; }
        public Guid? CompanyId { get; set; }
        public string UserType { get; set; }
        public string Langu { get; set; }

        //TODO: Gülsüm gereksiz kısım var mı kontrol et
        public bool IsTenantUser { get; set; }
        public bool IsTenantAdmin { get; set; }
        public bool IsCompanyUser { get; set; }
        public List<string> Roles { get; set; }

    }
}
