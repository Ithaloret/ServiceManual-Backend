using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EtteplanMORE.ServiceManual.ApplicationCore;

public class DevicesDbContext : DbContext
{
    public DevicesDbContext(DbContextOptions<DevicesDbContext> options) : base(options)
    {
    }
    public DbSet<FactoryDevice> FactoryDevices { get; set; }
    public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FactoryDevice>().ToTable("FactoryDevice");
        modelBuilder.Entity<MaintenanceTask>().ToTable("MaintenanceTask");
        Guid guid = Guid.NewGuid();
        modelBuilder.Entity<FactoryDevice>().HasData(new FactoryDevice { DeviceId = guid, Name = "Device 0", Type = "Type 19", Year = 2004 });
        modelBuilder.Entity<MaintenanceTask>().HasData(new MaintenanceTask { TaskId = Guid.NewGuid(), Name = "Regular Check", Description = "Regular check of the device", DeviceId = guid, Severity = "SERIOUS", CreationDate = DateTime.UtcNow, ModificationDate = DateTime.UtcNow, Status = "Open" });
    }
}