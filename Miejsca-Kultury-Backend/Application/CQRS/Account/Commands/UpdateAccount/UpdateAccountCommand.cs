using Application.Contracts.Account;
using MediatR;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public record UpdateAccountCommand(
    string Token,
    string NewPassword,
    string ConfirmPassword
) : IRequest<UpdateAccountResponse>;

