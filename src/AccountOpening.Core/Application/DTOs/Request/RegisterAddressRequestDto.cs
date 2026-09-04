namespace AccountOpening.Core.Application.DTOs.Request;

public sealed record RegisterAddressRequestDto : Dto
{
    public required string City { get; init; }
    public required string State { get; init; }
    public required string ZipCode { get; init; }
    public required Guid ClientId { get; init; }
}