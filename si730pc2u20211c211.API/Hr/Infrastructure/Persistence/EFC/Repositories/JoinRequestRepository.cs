using Microsoft.EntityFrameworkCore;
using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Domain.Repositories;
using si730pc2u20211c211.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730pc2u20211c211.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730pc2u20211c211.API.Hr.Infrastructure.Persistence.EFC.Repositories;

public class JoinRequestRepository(AppDbContext context) : BaseRepository<JoinRequest>(context), IJoinRequestRepository
{
    public async Task<JoinRequest?> FinByCustomerAndFabricId(string name, int departmentId)
    {
        return await Context.Set<JoinRequest>()
            .Where(p => p.Name == name && p.DepartmentId == departmentId)
            .FirstOrDefaultAsync();
    }
}