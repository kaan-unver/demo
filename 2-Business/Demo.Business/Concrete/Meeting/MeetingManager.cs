using AutoMapper;
using Demo.Business.Abstract.Messages;
using Demo.Business.Abstract.Meeting;
using Demo.Business.Helper;
using Demo.Business.Helpers;
using Demo.Business.Validations;
using Demo.Core.ConfigManager;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.DTO.Meeting;
using Demo.Entities.Models;
using Demo.Infrastructure.Abstract.Meeting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Xeneff.Business.Concrete.Meeting
{
    internal class MeetingManager(IHttpContextAccessor httpContextAccessor, IMeetingRepository meetingRepository,
       IMessageManager messageManager, IConfigManager configManager, IMapper mapper) : ContextHelper(httpContextAccessor), IMeetingManager
    {
        private readonly IMeetingRepository _meetingRepository = meetingRepository;
        private readonly IMessageManager _messageManager = messageManager;
        private readonly IConfigManager _configManager = configManager;
        private readonly IMapper _mapper = mapper;

        public IDataResult<List<MeetingDto>> GetAll()
        {
            var response = _meetingRepository.GetAll().ToList();
            if (response != null && response.Any())
                return new SuccessDataResult<List<MeetingDto>>(_mapper.Map<List<Demo.Entities.Models.Meeting>, List<MeetingDto>>(response), Constants.Ok);

            return new ErrorDataResult<List<MeetingDto>>(Constants.Ok);
        }
        public IDataResult<MeetingDto> Add(InsertMeetingDto dto)
        {
            var result = new InsertMeetingValidator(_messageManager).Validate(dto);
            if (!result.IsValid)
                return new ErrorDataResult<MeetingDto>(Constants.BadRequest, MessageCode, TransactionId, result.Errors.Select(x => x.ErrorMessage).ToList());
            var data = _mapper.Map<InsertMeetingDto, Demo.Entities.Models.Meeting>(dto, opt => opt.AfterMap((src, dest) =>
            {
                dest.FileId = src.File != null ? Guid.Parse(FileHelper.SavePdf(src.File, _configManager.ProfilePhotoFilePath).Result) : null;
                dest.UserId = User.Id;
            }));

            var response = _meetingRepository.Add(data);
            if (response)
            {
                return new SuccessDataResult<MeetingDto>(_mapper.Map<Demo.Entities.Models.Meeting, MeetingDto>(data), Constants.Ok);
            }
            else
                return new ErrorDataResult<MeetingDto>(Constants.InternalServer, MessageCode, TransactionId, MessageCodes.InsertError);
        }
        public IDataResult<Guid> Delete(Guid id)
        {
            var entity = _meetingRepository.Get(id);
            if (entity == null)
                return new ErrorDataResult<Guid>(Constants.Ok, MessageCode, TransactionId, _messageManager.Message(MessageCodes.ProcessedDataNotFound));

            var response = _meetingRepository.Delete(entity);
            if (response)
                return new SuccessDataResult<Guid>(id, Constants.Ok);
            return new ErrorDataResult<Guid>(Constants.InternalServer, MessageCode, TransactionId, _messageManager.Message(MessageCodes.DeleteError));

        }
        #region Private Methods
        #endregion
    }
}
