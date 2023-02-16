using System;
using System.ComponentModel.DataAnnotations;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Entities;

public class MaintenanceTask
{
    [Key]
    public Guid TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Severity { get; set; }         //critical, important, and unimportant.
    public Guid DeviceId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ModificationDate { get; set; }
    public string Status { get; set; }

}