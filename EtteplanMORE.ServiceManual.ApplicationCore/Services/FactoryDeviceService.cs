using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Services;

public class FactoryDeviceService : IFactoryDeviceService
{
    /// <summary>
    ///     Remove this. Temporary device storage before proper data storage is implemented.
    /// </summary>
    private readonly DevicesDbContext db;

    public FactoryDeviceService(DevicesDbContext _db)
    {
        db = _db;
    }
    public async Task<IEnumerable<FactoryDevice>> GetAll()
    {
        return await db.FactoryDevices.ToListAsync();
    }

    public async Task<FactoryDevice> Get(Guid id)
    {
        return await db.FactoryDevices.FirstOrDefaultAsync(x => x.DeviceId == id);
    }
}