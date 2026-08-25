namespace AccountOpening.Core.Application.DTOs.Request
{
    public sealed record RegisterClientRequestDto : Dto
    {
        public required string Name { get; init; }
        public required DateTime DateOfBirth { get; init; }
        public required string Document { get; init; }
    }
}
