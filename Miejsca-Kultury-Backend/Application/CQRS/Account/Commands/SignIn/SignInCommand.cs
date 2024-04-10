using Application.Contracts.Account;
using MediatR;

namespace Application.CQRS.Account.Commands.SignIn;

public record SignInCommand(
    string Email,
    string Password
    ) : IRequest<SignInResponse>;