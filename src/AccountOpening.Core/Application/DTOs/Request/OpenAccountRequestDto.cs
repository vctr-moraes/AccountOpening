namespace AccountOpening.Core.Application.DTOs.Request
{
    internal record OpenAccountRequestDto
    {
        public required Guid ClientId { get; init; }
    }
}
