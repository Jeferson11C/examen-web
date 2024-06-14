using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Domain.Model.Queries;

namespace si730pc2u20211c211.API.Hr.Domain.Services;

public interface IJoinRequestQueryService
{
    Task<JoinRequest?> Handle(GetByJoinRequestCustomerAndFabricIdQuery query);
}