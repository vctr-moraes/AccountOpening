namespace AccountOpening.Core.Application.DTOs.Request
{
    internal record RegisterClientRequestDto
    {
        public required string Name { get; init; }
        public required DateTime DateOfBirth { get; init; }
        public required string Document { get; init; }
    }
}
