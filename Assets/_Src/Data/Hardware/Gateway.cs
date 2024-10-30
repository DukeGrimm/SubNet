using EmberToolkit.Unity.Data;
using SubNet.Common.Interfaces.Data.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubNet.Data.Hardware
{
    [System.Serializable]
    public class Gateway : EmberObject, IGateway
    {
        private int maxCPUSlots;
        private int maxRAMSlots;
        private int maxDataShardSlots;

        private List<Guid> cpus;
        private List<Guid> rams;
        private List<Guid> dataShards;


        public override Type ItemType => GetType();


        public int MaxCPUSlots => maxCPUSlots;
        public int MaxRAMSlots => maxRAMSlots;
        public int MaxDataShardSlots => maxDataShardSlots;

        public IEnumerable<Guid> Cpus => cpus.AsEnumerable();
        public IEnumerable<Guid> Rams => rams.AsEnumerable();
        public IEnumerable<Guid> DataShards => dataShards.AsEnumerable();

        public Gateway() :base("Empty Gateway")
        {
            cpus = new List<Guid>();
            rams = new List<Guid>();
            dataShards = new List<Guid>();
        }

        public Gateway(IGateway gateway) : base(gateway.Id, gateway.Name)
        {
            maxCPUSlots = gateway.MaxCPUSlots;
            maxRAMSlots = gateway.MaxRAMSlots;
            maxDataShardSlots = gateway.MaxDataShardSlots;

            cpus = new List<Guid>(gateway.Cpus);
            rams = new List<Guid>(gateway.Rams);
            dataShards = new List<Guid>(gateway.DataShards);
        }

        public Gateway(IGatewayBase stock) : base(stock.Id, stock.Name)
        {
            maxCPUSlots = stock.MaxCPUSlots;
            maxRAMSlots = stock.MaxRAMSlots;
            maxDataShardSlots = stock.MaxDataShardSlots;

            cpus = new List<Guid>();
            rams = new List<Guid>();
            dataShards = new List<Guid>();
        }

        public void AddCpu(ICpu cpu) => cpus.Add(cpu.Id);
        public void AddCpu(Guid cpuId) => cpus.Add(cpuId);
        public void AddDataShard(IDataShard dataShard) => dataShards.Add(dataShard.Id);
        public void AddDataShard(Guid dataShardId) => dataShards.Add(dataShardId);
        public void AddRam(IRam ram) => rams.Add(ram.Id);
        public void AddRam(Guid ramId) => rams.Add(ramId);
        public void RemoveCpu(ICpu cpu) => cpus.Remove(cpu.Id);
        public void RemoveDataShard(IDataShard dataShard) => dataShards.Remove(dataShard.Id);
        public void RemoveRam(IRam ram) => rams.Remove(ram.Id);
    }
}
