using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Services;

public class MaintenanceTaskService : IMaintenanceTask
{
    private readonly DevicesDbContext db;

    public MaintenanceTaskService(DevicesDbContext _db)
    {
        db = _db;
    }
    public async Task CreateMaintenanceTask(MaintenanceTask maintenanceTask)
    {
        db.MaintenanceTasks.Add(maintenanceTask);
        await db.SaveChangesAsync();
    }

    public async Task DeleteMaintenanceTask(Guid maintenanceTaskId)
    {
        db.MaintenanceTasks.Remove(new MaintenanceTask() { TaskId = maintenanceTaskId });
        await db.SaveChangesAsync();
    }

    public async Task<MaintenanceTask> GetMaintenanceTaskById(Guid TaskId)
    {
        return (await db.MaintenanceTasks.Where(x => x.TaskId == TaskId).FirstOrDefaultAsync());
    }

    public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasks()
    {
        return (await db.MaintenanceTasks.ToListAsync());
    }

    public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByDeviceId(Guid DeviceId)
    {
        return await db.MaintenanceTasks.Where(x => x.DeviceId == DeviceId).ToListAsync();
    }

    public async Task UpdateMaintenanceTask(MaintenanceTask maintenanceTask)
    {
        db.MaintenanceTasks.Update(maintenanceTask);
        await db.SaveChangesAsync();
    }
}