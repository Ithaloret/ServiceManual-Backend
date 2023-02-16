namespace EtteplanMORE.ServiceManual.Web.Models;

public class CreateMaintenanceTaskRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Severity { get; set; }         //critical, important, and unimportant.
    public Guid DeviceId { get; set; }
}