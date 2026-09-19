using AccountOpening.Core.Domain.Entities;

namespace AccountOpening.Core.Domain.Interfaces.Repositories;

public interface IAgencyRepository : IRepository<Agency>
{
    Task<Agency?> GetDefaultAgency();
    void Update(Agency agency);
}