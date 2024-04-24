using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>, ITransactionalRequest
{
    public RegisterDto RegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        RegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(RegisterDto userForRegisterDto, string ipAddress)
    {
        RegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules
        )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }
        // Caching
        // Dynamic Query
        // Role Guard
        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.RegisterDto.User.Email);

            HashingHelper.CreatePasswordHash(
                request.RegisterDto.User.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.RegisterDto.User.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                createdUser,
                request.IpAddress
            );
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);


            Customer customer = new Customer();
            customer.UserId = createdUser.Id;


            RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
            return registeredResponse;
        }
    }
}
