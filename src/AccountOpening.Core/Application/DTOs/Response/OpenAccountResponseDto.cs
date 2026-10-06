namespace AccountOpening.Core.Application.DTOs.Response;

public sealed record OpenAccountResponseDto : Dto
{
    public string AccountType { get; init; }
    public string AccountNumber { get; init; }
    public string ClientName { get; init; }
}