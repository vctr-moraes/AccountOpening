namespace AccountOpening.Core.Application.DTOs.Response;

public sealed record RegisterClientResponseDto : Dto
{
    public string Name { get; init; } = string.Empty;
}