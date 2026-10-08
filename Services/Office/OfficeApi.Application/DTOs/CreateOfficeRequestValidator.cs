using FluentValidation;

namespace OfficeApi.Application.DTOs;

public class CreateOfficeRequestValidator : AbstractValidator<CreateOfficeRequest>
{
    public CreateOfficeRequestValidator()
    {
        // описываем правила, значение не должно быть пустым, если правило нарушено, вернуть сообщение
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("pls, enter the office's city");
        
        RuleFor(x => x.Street)
            .NotEmpty()
            .WithMessage("pls, enter the office's street");
        
        RuleFor(x => x.HouseNumber)
            .NotEmpty()
            .WithMessage("pls, enter the office's house number");
        
        RuleFor(x => x.RegistryPhoneNumber)
            .NotEmpty()
            .WithMessage("pls, enter the phone number")
            .Matches(@"^\+\d+$")
            .WithMessage("you've entered an invalid phone number");
        
    }
}