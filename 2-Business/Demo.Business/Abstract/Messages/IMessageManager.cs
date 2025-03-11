using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.DTO.Messages;

namespace Demo.Business.Abstract.Messages
{
    public interface IMessageManager
    {
        string Message(string code, String language = Constants.DefaultLangu);
        IDataResult<List<MessagesDto>> GetActions();
        IDataResult<List<MessagesDto>> GetModuleNames();
        IDataResult<List<MessagesDto>> GetScreenNames();
    }
}
