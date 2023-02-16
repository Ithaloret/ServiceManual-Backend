using EtteplanMORE.ServiceManual.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EtteplanMORE.ServiceManual.ApplicationCore.Interfaces;

public interface IFactoryDeviceService
{
    Task<IEnumerable<FactoryDevice>> GetAll();

    Task<FactoryDevice> Get(Guid id);
}