using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Domain.Model.Queries;
using si730pc2u20211c211.API.Hr.Domain.Repositories;
using si730pc2u20211c211.API.Hr.Domain.Services;
using si730pc2u20211c211.API.Shared.Domain.Repositories;

namespace si730pc2u20211c211.API.Hr.Application.Internal.QueryServices;

public class JoinRequestQueryService(IJoinRequestRepository joinRequestRepository, IUnitOfWork unitOfWork) : IJoinRequestQueryService
{
    public async Task<JoinRequest?> Handle(GetByJoinRequestCustomerAndFabricIdQuery query)
    {
        return await joinRequestRepository.FinByCustomerAndFabricId(query.Name, query.DepartmentId);
    }
}