using si730pc2u20211c211.API.Hr.Domain.Model.Commands;

namespace si730pc2u20211c211.API.Hr.Domain.Model.Aggregates;

public enum EJoinRequest
{
    DriversOrLogisticSupport = 1,
    ServiceOrMaintenanceOrTrades = 2,
    ManagmentOrOperations = 3,
    AccountingOrFinance = 4,
    SalesOrMarketing = 5,
    ITOrTelecomOrData = 6,
    HROrLegalOrTraining = 7,
    Internships = 8,
    SafetyOrRiskManagement = 9
};
public partial class JoinRequest
{
    /// <summary>
    /// Ciase de uso: Crear solicitud de unirse a la empresa
    /// tiene como atributos:
    /// Id: identificador de la solicitud
    /// Name: nombre del solicitante
    /// DepartmentId: identificador del departamento al que se quiere unir
    /// DesiredJobTitle: titulo del trabajo deseado
    /// ResumeUrl: url del curriculum
    /// </summary>
    public int Id { get; }
    public string Name { private set; get; }
    public int DepartmentId { private set; get; }
    public string DesiredJobTitle { private set; get; }
    public string ResumeUrl { private set; get; }
    
    public JoinRequest() {
        this.Name = string.Empty;
        this.DepartmentId = 0;
        this.DesiredJobTitle = string.Empty;
        this.ResumeUrl = string.Empty;
    }

    public JoinRequest(string name, int departmentId, string desiredJobTitle, string resumeUrl)
    {
        this.Name = name;
        this.DepartmentId = departmentId;
        this.DesiredJobTitle = desiredJobTitle;
        this.ResumeUrl = resumeUrl;
    }
    
    public JoinRequest(CreateJoinRequestCommand command) {
        this.Name = command.Name;
        this.DepartmentId = command.DepartmentId;
        this.DesiredJobTitle = command.DesiredJobTitle;
        this.ResumeUrl = command.ResumeUrl;
    }
}