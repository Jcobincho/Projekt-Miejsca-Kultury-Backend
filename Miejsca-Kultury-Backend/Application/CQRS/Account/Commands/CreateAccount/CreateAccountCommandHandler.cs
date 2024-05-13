using Application.CQRS.Account.Events.SendConfirmAccountEmail;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Application.CQRS.Account.Commands.CreateAccount;

public sealed class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
{
    private readonly UserManager<Users> _userManager;
    private readonly IAccountRepository _accountRepository;
    private readonly IMediator _mediator;

    public CreateAccountCommandHandler(UserManager<Users> userManager, IAccountRepository accountRepository, IMediator mediator)
    {
        _userManager = userManager;
        _accountRepository = accountRepository;
        _mediator = mediator;
    }


    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var userId = await _accountRepository.CreateUserAsync(request.Email, request.Password, request.Name, 
            request.Surname, cancellationToken);

        await _mediator.Publish(new SendConfirmAccountEmailEvent(userId), cancellationToken);

        await _accountRepository.SaveChangesAsync(cancellationToken);
    }
}