using si730pc2u20211c211.API.Hr.Domain.Model.Commands;
using si730pc2u20211c211.API.Hr.Interfaces.REST.Resources;

namespace si730pc2u20211c211.API.Hr.Interfaces.REST.Transform;

public class CreateJoinRequestCommandFromResourceAssembler
{
    public static CreateJoinRequestCommand ToCommandFromResource(CreateJoinRequestResource resource)
    {
        return new CreateJoinRequestCommand(resource.Name, resource.DepartmentId, resource.DesiredJobTitle, resource.ResumeUrl);
    }
}