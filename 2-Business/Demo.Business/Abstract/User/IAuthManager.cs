using Demo.DTO.User;
using Demo.Core.Utilities.Results;
using Demo.DTO.Auth;

namespace Demo.Business.Abstract.UserManager
{
    public interface IAuthManager
    {
        IDataResult<UserDto> GetUserByUserId(Guid userId, string tokenType);
        IDataResult<UserLoginResponseDto> GetUserByLogin(LoginUser dto);
    }
}
