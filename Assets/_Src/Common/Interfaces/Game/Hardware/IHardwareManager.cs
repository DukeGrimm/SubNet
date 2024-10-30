using SubNet.Common.Interfaces.Data.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game.Hardware
{
    public interface IHardwareManager
    {
        IEnumerable<ICpu> GetAllCPUs();
        IEnumerable<IDataShard> GetAllDataShards();
        IEnumerable<IGatewayBase> GetAllGateways();
        IEnumerable<IRam> GetAllRAMs();
        ICpu GetCPU(Guid id);
        IDataShard GetDataShard(Guid id);
        IGatewayBase GetGateway(Guid id);
        IRam GetRAM(Guid id);

        //Group LookUps
        IEnumerable<ICpu> GetCPUs(IEnumerable<Guid> ids);
        IEnumerable<IDataShard> GetDataShards(IEnumerable<Guid> ids);
        IEnumerable<IRam> GetRAMs(IEnumerable<Guid> ids);
        //Component Value Calculators
        int GetTotalCPUSpeed(IEnumerable<Guid> ids);
        int GetTotalDataShardSize(IEnumerable<Guid> ids);
        int GetTotalRAMSize(IEnumerable<Guid> ids);
    }
}
