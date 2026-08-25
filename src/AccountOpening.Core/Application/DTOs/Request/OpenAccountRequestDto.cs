namespace AccountOpening.Core.Application.DTOs.Request
{
    public sealed record OpenAccountRequestDto : Dto
    {
        public required Guid ClientId { get; init; }
    }
}
