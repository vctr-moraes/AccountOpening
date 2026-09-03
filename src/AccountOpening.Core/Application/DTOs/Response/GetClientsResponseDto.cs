namespace AccountOpening.Core.Application.DTOs.Response;

public sealed record GetClientsResponseDto : Dto
{
    public List<ClientData> ClientData { get; init; } = new List<ClientData>();
}

public sealed record ClientData : Dto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public string Document { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}