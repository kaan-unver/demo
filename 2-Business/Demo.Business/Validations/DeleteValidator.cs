using FluentValidation;
using Demo.Business.Abstract.Messages;
using Demo.Core.Constants;
using Demo.DTO.Abstract;

namespace Demo.Business.Validations
{
    internal class DeleteValidator : AbstractValidator<List<DeleteEntry>>
    {
        public DeleteValidator(IMessageManager messageManager)
        {
            RuleForEach(model => model).NotNull().WithMessage(MessageCodes.ListCannotBeEmpty);         
        }
      
    }
}

