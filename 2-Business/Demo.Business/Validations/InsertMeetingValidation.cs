using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Meeting;

namespace Demo.Business.Validations
{
    internal class InsertMeetingValidator : AbstractValidator<InsertMeetingDto>
    {
        public InsertMeetingValidator(IMessageManager messageManager)
        {
            RuleFor(s => s.StartDate).NotEmpty().WithMessage(MessageCodes.StartDateIsRequired);
            RuleFor(s => s.EndDate).NotEmpty().WithMessage(MessageCodes.EndDateIsRequired);
            RuleFor(s => s.Title).NotEmpty().WithMessage(MessageCodes.TitleIsRequired);
        }
    }
}
