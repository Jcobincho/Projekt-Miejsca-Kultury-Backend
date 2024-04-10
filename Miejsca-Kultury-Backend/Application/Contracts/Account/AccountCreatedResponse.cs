using MediatR;

namespace Application.Contracts.Account;

public record AccountCreatedResponse(Guid Id) : IRequest;