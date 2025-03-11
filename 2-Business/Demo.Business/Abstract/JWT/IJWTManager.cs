using Demo.Core.Utilities.Results;

namespace Demo.Business.Abstract.JWT
{
    public interface IJWTManager
    {
        IDataResult<string> GetToken(Guid userId);
        IDataResult<Guid> GetUserGuidFromValidatedToken(string token);
    }
}
