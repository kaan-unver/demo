using Demo.Core.Models;
using Microsoft.AspNetCore.Http;
namespace Demo.DTO.Meeting
{
    public class InsertMeetingDto : IDto
    {
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public IFormFile File { get; set; }
    }
}
