using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Domain.Model.Commands;

namespace si730pc2u20211c211.API.Hr.Domain.Services;

public interface IJoinRequestCommandService
{
    Task<JoinRequest?> Handle(CreateJoinRequestCommand command);
}