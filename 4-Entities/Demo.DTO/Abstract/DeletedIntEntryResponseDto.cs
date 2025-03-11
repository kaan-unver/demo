
using Demo.Core.Models;

namespace Demo.DTO.Abstract
{
    public class DeletedIntEntryResponseDto : IDto
    {
        public List<DeleteIntEntryDto> DeletedEntries { get; set; }
        public List<DeleteIntEntryDto> NotDeletedEntries { get; set; }
    }
}
