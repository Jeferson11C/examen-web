using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Shared.Domain.Repositories;

namespace si730pc2u20211c211.API.Hr.Domain.Repositories;

public interface IJoinRequestRepository : IBaseRepository<JoinRequest>
{
    Task<JoinRequest?> FinByCustomerAndFabricId(string customer, int fabricId);
}