using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using Application.Persistance.Interfaces.ClaimUserId;
using MediatR;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        bool result = await _accountRepository.ResetPassword(request.Token, request.NewPassword, cancellationToken);

        return new UpdateAccountResponse("Pomyślnie zmieniono hasło!");
    }
}