using MediatR;

namespace Application.CQRS.Account.Commands.ConfirmAccount;

public sealed record ConfirmAccountCommand(Guid UserId, string Token) : IRequest;