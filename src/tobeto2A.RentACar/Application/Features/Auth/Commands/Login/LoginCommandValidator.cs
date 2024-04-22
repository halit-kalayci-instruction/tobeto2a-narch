using Application.Features.Auth.Constants;
using FluentValidation;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    private ILocalizationService _localizationService;
    public LoginCommandValidator(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        RuleFor(c => c.UserForLoginDto.Email).NotEmpty();
        RuleFor(c => c.UserForLoginDto.Email).EmailAddress().WithMessage(GetLocalized("EmailFormatError").Result);
        RuleFor(c => c.UserForLoginDto.Password).NotEmpty().MinimumLength(4);
    }
    public async Task<string> GetLocalized(string key)
    {
        return await _localizationService.GetLocalizedAsync(key, AuthMessages.SectionName);
    }
}
