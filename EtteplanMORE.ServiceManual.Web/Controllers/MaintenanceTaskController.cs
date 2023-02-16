using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EtteplanMORE.ServiceManual.Web.Controllers;

[Route("api/[controller]/[action]")]
public class MaintenanceTaskController : Controller
{
    private readonly IMaintenanceTask _maintenanceService;

    public MaintenanceTaskController(IMaintenanceTask maintenanceService)
    {
        _maintenanceService = maintenanceService;
    }

    [HttpGet]
    public async Task<IEnumerable<MaintenanceTask>> GetList()
    {
        var list = await _maintenanceService.GetMaintenanceTasks();
        return list;
    }
    [HttpGet("{DeviceId}")]
    public async Task<IEnumerable<MaintenanceTask>> GetMaintenanceTasksByDeviceId(Guid DeviceId)
    {
        return await _maintenanceService.GetMaintenanceTasksByDeviceId(DeviceId);
    }
    [HttpGet("{TaskId}")]
    public async Task<MaintenanceTask> GetMaintenanceTaskById(Guid TaskId)
    {
        return (await _maintenanceService.GetMaintenanceTaskById(TaskId));
    }
    [HttpPost]
    public async Task CreateMaintenanceTask([FromBody] CreateMaintenanceTaskRequest reqData)
    {
        await _maintenanceService.CreateMaintenanceTask(new MaintenanceTask() { TaskId = Guid.NewGuid(), Description = reqData.Description, DeviceId = reqData.DeviceId, Name = reqData.Name, Severity = reqData.Severity, CreationDate = DateTime.UtcNow, ModificationDate = DateTime.UtcNow, Status = reqData.Status });
    }
    [HttpPost]
    public async Task<IActionResult> UpdateMaintenanceTask([FromBody] UpdateMaintenanceTaskRequest reqData)
    {
        var task = await _maintenanceService.GetMaintenanceTaskById(reqData.TaskId);
        if (task != null)
        {
            await _maintenanceService.UpdateMaintenanceTask(new MaintenanceTask() { TaskId = reqData.TaskId, Description = reqData.Description, Name = reqData.Name, Severity = reqData.Severity, DeviceId = task.DeviceId, CreationDate = task.CreationDate, ModificationDate = DateTime.UtcNow, Status = reqData.Status });
        }
        else
        {
            return Ok(HttpStatusCode.NotFound);
        }
        return Ok(HttpStatusCode.OK);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteMaintenanceTask(Guid TaskId)
    {
        var task = await _maintenanceService.GetMaintenanceTaskById(TaskId);
        if (task != null)
        {
            await _maintenanceService.DeleteMaintenanceTask(TaskId);
        }
        else
        {
            return Ok(HttpStatusCode.NotFound);
        }
        return Ok(HttpStatusCode.OK);
    }
}