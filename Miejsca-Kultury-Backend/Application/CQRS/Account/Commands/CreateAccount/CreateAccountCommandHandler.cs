using System.Security.Claims;
using Application.CQRS.Account.Static;
using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Account.Commands.CreateAccount;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
{
    private readonly UserManager<Users> _userManager;
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(UserManager<Users> userManager, IAccountRepository accountRepository)
    {
        _userManager = userManager;
        _accountRepository = accountRepository;
    }


    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var isEmailExist = await _userManager.Users.AnyAsync(x => x.Email == request.Email, cancellationToken);
        if (isEmailExist) throw new BadRequestException("Podaj inny email");

        var user = new Users
        {
            Email = request.Email,
            UserName = request.Email,
            Name = request.Name,
            Surname = request.Surname
        };

        var createUser = await _userManager.CreateAsync(user, request.Password);
        if (!createUser.Succeeded) throw new BadRequestException("Nie udało się stworzyć urzytkownika1!");

        var addUserRole = await _userManager.AddToRoleAsync(user, UserRoles.User);
        if (!addUserRole.Succeeded) throw new BadRequestException("Nie udało się dodać roli");

        var addNameClaim =
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        if (!addNameClaim.Succeeded) throw new BadRequestException("Nie udało się dodać claima");

        await _accountRepository.SaveChangesAsync(cancellationToken);
    }
}