using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Entities;

public class FactoryDevice
{
    [Key]
    public Guid DeviceId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
    public List<MaintenanceTask> Tasks { get; set; }
}