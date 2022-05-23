using FluentValidation;

namespace Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(80).WithMessage("{PropertyName} can be higher than {MaxLength} caracters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(80).WithMessage("{PropertyName} can be higher than {MaxLength} caracters");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("{PropertyName} can not be empty");

            RuleFor(p => p.Telephone)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                //.Matches(@"^\d{4}$").WithMessage("{PropertyName} need to have the format 0000-000000000")
                .MaximumLength(9).WithMessage("{PropertyName} can be higher than {MaxLength} caracters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .EmailAddress().WithMessage("{PropertyName} need to be a valid email format")
                .MaximumLength(80).WithMessage("{PropertyName} can be higher than {MaxLength} caracters");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} can not be empty")
                .MaximumLength(120).WithMessage("{PropertyName} can be higher than {MaxLength} caracters");
        }
    }
}
