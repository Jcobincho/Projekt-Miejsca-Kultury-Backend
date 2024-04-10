using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.CQRS.Account.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, SignInResponse>
{
    private readonly IAccountRepository _accountRepository;

    public SignInCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task<SignInResponse> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var token = await _accountRepository.SignIn(request.Email, request.Password, cancellationToken);

        if (token is null) throw new BadRequestException("Podaj poprawne dane logowania");

        return new SignInResponse(token);
    }
}