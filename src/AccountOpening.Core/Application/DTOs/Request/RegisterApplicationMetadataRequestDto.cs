namespace AccountOpening.Core.Application.DTOs.Request;

public sealed record RegisterApplicationMetadataRequestDto : Dto
{
    public required short TransactionalPassword { get; init; }
    public required Guid ClientId { get; set; }
}