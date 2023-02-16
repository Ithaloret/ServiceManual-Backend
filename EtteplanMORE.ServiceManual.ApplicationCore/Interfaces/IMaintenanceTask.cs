using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;

public interface IMaintenanceTask
{
    Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasks();
    Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByDeviceId(Guid DeviceId);
    Task<MaintenanceTask> GetMaintenanceTaskById(Guid TaskId);
    Task UpdateMaintenanceTask(MaintenanceTask maintenanceTask);
    Task CreateMaintenanceTask(MaintenanceTask maintenanceTask);
    Task DeleteMaintenanceTask(Guid maintenanceTaskId);

}