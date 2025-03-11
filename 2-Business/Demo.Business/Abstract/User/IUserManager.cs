using Demo.DTO.User;
using Demo.Core.Utilities.Results;
namespace Demo.Business.Abstract.User
{
    public interface IUserManager
    {
        IDataResult<TUserDto> Add(InsertTUserDto dto);
    }
}
