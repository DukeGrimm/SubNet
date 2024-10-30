using SubNet.Common.Interfaces.Data.Hardware;
using SubNet.Common.Interfaces.Data.Servers;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Game.Hardware
{
    public interface IGatewayManager
    {
        int GatewayCpuSpeed { get; }
        int GatewayDataShardSize { get; }
        int GatewayRamSize { get; }

        void AddCpu(ICpu cpu);
        void AddDataShard(IDataShard dataShard);
        void AddRam(IRam ram);
        IDataStorage GetLocalGatewayData();
        IEnumerable<ICpu> GetCpus();
        IEnumerable<IDataShard> GetDataShards();
        IEnumerable<IRam> GetRams();
        void RemoveCpu(ICpu cpu);
        void RemoveDataShard(IDataShard dataShard);
        void RemoveRam(IRam ram);
        void UpgradeGateway(IGatewayBase newGateway);
    }

}
