using Demo.DTO.User;
using Demo.Core.Utilities.Results;
using Demo.DTO.Meeting;
using Demo.DTO.Abstract;
namespace Demo.Business.Abstract.Meeting
{
    public interface IMeetingManager
    {
        IDataResult<List<MeetingDto>> GetAll();

        IDataResult<MeetingDto> Add(InsertMeetingDto dto);
        IDataResult<Guid> Delete(Guid id);
    }
}
