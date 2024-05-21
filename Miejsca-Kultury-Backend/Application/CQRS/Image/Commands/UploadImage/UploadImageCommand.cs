using Application.CQRS.Image.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Image.Commands.UploadImage;

public record UploadImageCommand(
    IFormFile Image
    ) : IRequest<UploadImageResponse>;