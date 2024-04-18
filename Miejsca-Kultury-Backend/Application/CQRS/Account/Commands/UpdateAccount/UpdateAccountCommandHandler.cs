using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using MediatR;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public class UpdateAccountCommandHandler:IRequestHandler<UpdateAccountCommand,UpdateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountRepository.UpdateAccount(request, cancellationToken);
        return new UpdateAccountResponse("Zaktualizowano konto");
    }
}