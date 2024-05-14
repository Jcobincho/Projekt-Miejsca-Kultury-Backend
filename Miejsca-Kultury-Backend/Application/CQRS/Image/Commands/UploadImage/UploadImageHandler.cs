using Application.CQRS.Image.Responses;
using Application.Persistance.Interfaces.S3StorageInterfaces;
using MediatR;

namespace Application.CQRS.Image.Commands.UploadImage;

public class UploadImageHandler : IRequestHandler<UploadImageCommand, UploadImageResponse>
{
    private readonly IS3StorageService _s3StorageService;

    public UploadImageHandler(IS3StorageService storageService)
    {
        _s3StorageService = storageService;
    }
    
    public async Task<UploadImageResponse> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var uploadResult = await _s3StorageService.UploadFileAsync(request.Image, cancellationToken);
        var url = await _s3StorageService.GetFileUrl(uploadResult);

        var image = new Domain.Entities.Image
        {
            Name = request.Image.Name,
            ContentType = request.Image.ContentType,
            TotalBytes = request.Image.Length,
            S3Key = uploadResult,
            Url = url
        };

        var id = await _s3StorageService.SaveChangesAsync(image, cancellationToken);
        return new UploadImageResponse(id , image);
    }
}