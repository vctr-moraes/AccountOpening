namespace AccountOpening.Core.Application.DTOs.Response;

public record GetClientByIdResponseDto : Dto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string Document { get; init; }
}