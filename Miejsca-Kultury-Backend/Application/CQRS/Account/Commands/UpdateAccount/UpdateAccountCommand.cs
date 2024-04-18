using Application.Contracts.Account;
using MediatR;

namespace Application.CQRS.Account.Commands.UpdateAccount;

public record UpdateAccountCommand(
    Guid Id,
    string? Name,
    string? Surname,
    string? Email):IRequest<UpdateAccountResponse>;
