using FluentValidation;

namespace Comunicacao.Messagem.Validations
{
    public class CustomerValidator : AbstractValidator<Message> 
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.PhoneNumberDestiny)
                .NotNull()
                .NotEmpty()
                .WithMessage("Required phoneNumber");

            RuleFor(customer => customer.MessageSend)
                .NotNull()
                .NotEmpty()
                .WithMessage("Required message body");

            RuleFor(x => x.PhoneNumberDestiny)
                .Length(11)
                .WithMessage("Invalid phone");
        }
    }
}