using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Image.Responses;

public record UploadImageResponse(Guid Id, Domain.Entities.Image Image);