namespace si730pc2u20211c211.API.Hr.Domain.Model.Commands;

public record CreateJoinRequestCommand(string Name, int DepartmentId, string DesiredJobTitle, string ResumeUrl);