using Demo.Core.Models;

namespace Demo.DTO.Messages
{
    public  class MessagesDto:IDto
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
