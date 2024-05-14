using Application.CQRS.Image.Commands.UploadImage;
using Application.Persistance.Interfaces.AccountInterfaces;
using MediatR;

namespace Application.CQRS.Account.Commands.UploadProfileImage;

public sealed class UploadProfileImageHandler : IRequestHandler<UploadProfileImageCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMediator _mediator;
    private readonly ICurrentUserService _currentUserService;

    public UploadProfileImageHandler(IAccountRepository accountRepository, IMediator mediator, ICurrentUserService currentUserService)
    {
        _accountRepository = accountRepository;
        _mediator = mediator;
        _currentUserService = currentUserService;
    }
    
    public async Task Handle(UploadProfileImageCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.UserId;

        var user = await _accountRepository.GetUserById(userId, cancellationToken);

        var fileResult = await _mediator.Send(new UploadImageCommand(request.Photo), cancellationToken);

        user.ImageId = fileResult.Id;
        await _accountRepository.UpdateUserImageAsync(user, cancellationToken);
    }
}