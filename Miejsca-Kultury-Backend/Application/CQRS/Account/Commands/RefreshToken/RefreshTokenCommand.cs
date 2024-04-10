using Application.Contracts.Account;
using MediatR;

namespace Application.CQRS.Account.Commands.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<SignInResponse>;