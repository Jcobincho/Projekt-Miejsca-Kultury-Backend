using Application.Persistance.Interfaces.AccountInterfaces;
using Domain.Authentication;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.CQRS.Account.Commands.SignIn;

public class SignInCommandHandler : IRequestHandler<SignInCommand, JsonWebToken>
{
    private readonly SignInManager<Users> _signInManager;
    private readonly UserManager<Users> _userManager;
    private readonly IAccountRepository _accountRepository;

    public SignInCommandHandler(SignInManager<Users> signInManager, UserManager<Users> userManager, IAccountRepository accountRepository)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _accountRepository = accountRepository;
    }

    public async Task<JsonWebToken> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _accountRepository.FindUserAsync(request.Email, cancellationToken);

        if (user is null) throw new NotFoundException("Podaj poprawne dane logowania!");

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
        if (!result.Succeeded) throw new NotFoundException("Podaj poprawne dane logowania!");

        var userRoles = await _userManager.GetRolesAsync(user);
        var userClaims = await _userManager.GetClaimsAsync(user);

        var jwt = _accountRepository.GenerateJwtToken(user.Id, user.Email, userRoles, userClaims);

        return jwt;
    }
}