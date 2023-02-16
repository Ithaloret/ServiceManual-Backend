using System.ComponentModel.DataAnnotations;

namespace EtteplanMORE.ServiceManual.Web.Models;

public class UpdateMaintenanceTaskRequest
{
    [Key]
    public Guid TaskId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string Severity { get; set; }         //critical, important, and unimportant.
}