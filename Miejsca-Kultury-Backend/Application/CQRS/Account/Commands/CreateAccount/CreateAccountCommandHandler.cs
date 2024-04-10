using Application.Contracts.Account;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Entities;
using Domain.Enums.RolesEnum;
using Domain.Exceptions;
using MediatR;

namespace Application.CQRS.Account.Commands.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, AccountCreatedResponse>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }


    public async Task<AccountCreatedResponse> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var isEmailExist = await _accountRepository.IsEmailExist(request.Email, cancellationToken);

        if (isEmailExist) throw new BadRequestException("Ten e-mail jest już zajęty");

        var user = new Users(request.Name, request.Surname, request.Email, request.Password, Roles.User);

        var userId = await _accountRepository.CreateAccount(user, cancellationToken);

        return new AccountCreatedResponse(userId);
    }
}