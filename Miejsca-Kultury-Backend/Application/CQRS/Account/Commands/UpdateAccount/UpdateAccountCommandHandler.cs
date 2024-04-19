using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using Application.Persistance.Interfaces.ClaimUserId;
using MediatR;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public class UpdateAccountCommandHandler:IRequestHandler<UpdateAccountCommand,UpdateAccountResponse>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IGetUserId _getUserId;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository,IGetUserId getUserId)
    {
        _accountRepository = accountRepository;
        _getUserId = getUserId;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        await _accountRepository.UpdateAccount(request, cancellationToken);
        return new UpdateAccountResponse("Zaktualizowano konto");
    }
}