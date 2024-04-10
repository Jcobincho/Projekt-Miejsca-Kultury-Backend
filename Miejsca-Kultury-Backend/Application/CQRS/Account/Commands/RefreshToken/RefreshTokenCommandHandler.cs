using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.CQRS.Account.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, SignInResponse>
{
    private readonly IAccountRepository _accountRepository;

    public RefreshTokenCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task<SignInResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await _accountRepository.RefreshToken(request.RefreshToken, cancellationToken);

        if (token is null) throw new UnauthorizedException("Niepoprawny token lub token wygasł");

        return new SignInResponse(token);
    }
}