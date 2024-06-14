namespace si730pc2u20211c211.API.Hr.Interfaces.REST.Resources;

public record CreateJoinRequestResource(string Name, int DepartmentId, string DesiredJobTitle, string ResumeUrl);