using MediatR;

namespace Application.CQRS.Account.Events.SendResetPasswordEmail;

public sealed record SendResetPasswordEmailEvent(string Email ) : INotification;