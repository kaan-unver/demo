using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;

namespace Demo.Business.Validations
{
    internal class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator(IMessageManager messageManager)
        {
            RuleFor(s => s).NotEmpty().WithMessage(MessageCodes.IdIsRequiered);
        }
    }
}
