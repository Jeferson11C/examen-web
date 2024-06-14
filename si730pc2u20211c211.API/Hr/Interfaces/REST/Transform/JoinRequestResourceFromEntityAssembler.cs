using si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;
using si730pc2u20211c211.API.Hr.Interfaces.REST.Resources;

namespace si730pc2u20211c211.API.Hr.Interfaces.REST.Transform;

public class JoinRequestResourceFromEntityAssembler
{
    public static JoinRequestResource ToResourceFromEntity(JoinRequest entity)
    {
        return new JoinRequestResource(entity.Id,entity.Name, entity.DepartmentId.ToString(), entity.DesiredJobTitle, entity.ResumeUrl);
    }
}