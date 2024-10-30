using EmberToolkit.Common.Interfaces.Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Hardware
{
    public interface IGateway : IGatewayBase, IEmberObject 
    {

        IEnumerable<Guid> Cpus { get; }
        IEnumerable<Guid> Rams { get; }
        IEnumerable<Guid> DataShards { get; }

        void AddCpu(ICpu cpu);
        void AddCpu(Guid cpu);
        void AddRam(IRam ram);
        void AddRam(Guid ram);
        void AddDataShard(IDataShard dataShard);
        void AddDataShard(Guid dataShard);
        void RemoveDataShard(IDataShard dataShard);
        void RemoveCpu(ICpu cpu);
        void RemoveRam(IRam ram);


    }
}
