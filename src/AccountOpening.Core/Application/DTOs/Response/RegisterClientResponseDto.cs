namespace AccountOpening.Core.Application.DTOs.Response;

public sealed record RegisterClientResponseDto : Dto
{
    public string Greetings { get; init; } = string.Empty;
}