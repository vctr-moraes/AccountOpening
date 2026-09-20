namespace AccountOpening.Core.Application.DTOs.Request;

public sealed record RegisterClientContactsRequestDto : Dto
{
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
    public required Guid ClientId { get; set; }
}