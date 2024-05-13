using Application.Persistance.Interfaces.AccountInterfaces;
using MediatR;

namespace Application.CQRS.Account.Commands.ResetPassword;

public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand>
{
    private readonly IAccountRepository _accountRepository;

    public ResetPasswordHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await _accountRepository.ResetPasswordAssync(request.Token, request.UserId, request.Password,
            cancellationToken);
    }
}