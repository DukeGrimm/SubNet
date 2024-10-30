using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.Hardware;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.Hardware;
using SubNet.Common.ScriptableObjects.Hardware;
using System;
using System.Collections.Generic;

namespace SubNet.Game.Managers.Data
{

    public class HardwareManager : EmberSingleton, IHardwareManager
    {
        private IContentController _contentController;

        [ShowInInspector][ReadOnly]
        private Dictionary<Guid, ICpu> stockCPUs = new Dictionary<Guid, ICpu>();
        [ShowInInspector][ReadOnly]
        private Dictionary<Guid, IRam> stockRAMs = new Dictionary<Guid, IRam>();
        [ShowInInspector][ReadOnly]
        private Dictionary<Guid, IDataShard> stockDataShards = new Dictionary<Guid, IDataShard>();
        [ShowInInspector][ReadOnly]
        private Dictionary<Guid, IGatewayBase> stockGateways = new Dictionary<Guid, IGatewayBase>();

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _contentController);
            LoadComponentResources();
        }

        void LoadComponentResources()
        {
            _contentController.LoadContentFromResources<CpuSO, ICpu>("CPUs", cpuSO => cpuSO as ICpu, HandleLoadedCpus);
            _contentController.LoadContentFromResources<RamSO, IRam>("RAM", ramSO => ramSO as IRam, HandleLoadedRams);
            _contentController.LoadContentFromResources<DataShardSO, IDataShard>("DataShards", dataShardSO => dataShardSO as IDataShard, HandleLoadedDataShards);
            _contentController.LoadContentFromResources<GatewaySO, IGatewayBase>("Gateways", gatewaySO => gatewaySO as IGatewayBase, HandleLoadedGateways);
        }
        #region Loaders

        void HandleLoadedCpus(List<ICpu> cpus)
        {
            foreach (var cpu in cpus)
            {
                stockCPUs.Add(cpu.Id, cpu);
            }
        }
        void HandleLoadedRams(List<IRam> rams)
        {
            foreach (var ram in rams)
            {
                stockRAMs.Add(ram.Id, ram);
            }
        }
        void HandleLoadedDataShards(List<IDataShard> dataShards)
        {
            foreach (var dataShard in dataShards)
            {
                stockDataShards.Add(dataShard.Id, dataShard);
            }
        }
        void HandleLoadedGateways(List<IGatewayBase> gateways)
        {
            foreach (var gateway in gateways)
            {
                stockGateways.Add(gateway.Id, gateway);
            }
        }
        #endregion                                                                        

        #region CRUD
        public IEnumerable<ICpu> GetAllCPUs() => stockCPUs.Values;
        public IEnumerable<IRam> GetAllRAMs() => stockRAMs.Values;
        public IEnumerable<IDataShard> GetAllDataShards() => stockDataShards.Values;
        public IEnumerable<IGatewayBase> GetAllGateways() => stockGateways.Values;

        public ICpu GetCPU(Guid id) => stockCPUs[id];
        public IRam GetRAM(Guid id) => stockRAMs[id];
        public IDataShard GetDataShard(Guid id) => stockDataShards[id];
        public IGatewayBase GetGateway(Guid id) => stockGateways[id];

        //Group LookUps
        public IEnumerable<ICpu> GetCPUs(IEnumerable<Guid> ids)
        {
            List<ICpu> cpus = new List<ICpu>();
            foreach (var id in ids)
            {
                cpus.Add(stockCPUs[id]);
            }
            return cpus;
        }
        public IEnumerable<IRam> GetRAMs(IEnumerable<Guid> ids)
        {
            List<IRam> rams = new List<IRam>();
            foreach (var id in ids)
            {
                rams.Add(stockRAMs[id]);
            }
            return rams;
        }
        public IEnumerable<IDataShard> GetDataShards(IEnumerable<Guid> ids)
        {
            List<IDataShard> dataShards = new List<IDataShard>();
            foreach (var id in ids)
            {
                dataShards.Add(stockDataShards[id]);
            }
            return dataShards;
        }
        //Component Value Calculators
        public int GetTotalCPUSpeed(IEnumerable<Guid> cpuIds)
        {
            int totalSpeed = 0;
            foreach (var id in cpuIds)
            {
                totalSpeed += stockCPUs[id].Speed;
            }
            return totalSpeed;
        }
        public int GetTotalRAMSize(IEnumerable<Guid> ramIds)
        {
            int totalSize = 0;
            foreach (var id in ramIds)
            {
                totalSize += stockRAMs[id].Size;
            }
            return totalSize;
        }
        public int GetTotalDataShardSize(IEnumerable<Guid> dataShardIds)
        {
            int totalSize = 0;
            foreach (var id in dataShardIds)
            {
                totalSize += stockDataShards[id].Size;
            }
            return totalSize;
        }
        
        #endregion

    }
}
