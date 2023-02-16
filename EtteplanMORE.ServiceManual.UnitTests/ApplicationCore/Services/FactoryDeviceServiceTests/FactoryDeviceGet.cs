using EtteplanMORE.ServiceManual.ApplicationCore;
using EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;
using EtteplanMORE.ServiceManual.ApplicationCore.Services;
using System;
using System.Linq;
using Xunit;

namespace EtteplanMORE.ServiceManual.UnitTests.ApplicationCore.Services.FactoryDeviceServiceTests;

public class FactoryDeviceGet
{
    private readonly DevicesDbContext db;

    public FactoryDeviceGet(DevicesDbContext _db)
    {
        db = _db;
    }
    [Fact]
    public async void AllCars()
    {
        IFactoryDeviceService factoryDeviceService = new FactoryDeviceService(db);

        var fds = (await factoryDeviceService.GetAll()).ToList();

        Assert.NotNull(fds);
        Assert.NotEmpty(fds);
        Assert.Equal(3, fds.Count);
    }

    [Fact]
    public async void ExistingCardWithId()
    {
        IFactoryDeviceService FactoryDeviceService = new FactoryDeviceService(db);
        Guid fdId = Guid.NewGuid();

        var fd = await FactoryDeviceService.Get(fdId);

        Assert.NotNull(fd);
        Assert.Equal(fdId, fd.DeviceId);
    }

    [Fact]
    public async void NonExistingCardWithId()
    {
        IFactoryDeviceService FactoryDeviceService = new FactoryDeviceService(db);
        Guid fdId = Guid.NewGuid();

        var fd = await FactoryDeviceService.Get(fdId);

        Assert.Null(fd);
    }
}