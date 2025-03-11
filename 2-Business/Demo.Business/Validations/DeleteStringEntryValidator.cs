

using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Abstract;

namespace Demo.Business.Validations
{
    internal class DeleteStringEntryValidator : AbstractValidator<List<DeleteStringEntryDto>>
    {
        public DeleteStringEntryValidator(IMessageManager messageManager)
        {
            RuleForEach(p => p).NotNull().WithMessage(MessageCodes.ListCannotBeEmpty);
        }

    }
}
