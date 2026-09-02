namespace AccountOpening.Core.Application.DTOs.Request;

public sealed record GetClientByIdRequestDto : Dto
{
    public required Guid ClientId { get; init; }
}