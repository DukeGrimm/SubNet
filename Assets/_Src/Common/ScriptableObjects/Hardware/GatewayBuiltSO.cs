using SubNet.Common.Interfaces.Data.Hardware;
using SubNet.Common.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects.Hardware
{
    [CreateAssetMenu(fileName = "New Premade Gateway", menuName = "Content/Hardware/GatewayBuiltSO", order = 1)]
    public class GatewayBuiltSO : ScriptableEmber, IGatewayBase
    {
        [SerializeField] private GatewaySO SourceGateway;

        [SerializeField] private int maxCPUSlots;
        [SerializeField] private int maxRAMSlots;
        [SerializeField] private int maxDataShardSlots;

        [SerializeField] private List<CpuSO> CPU;
        [SerializeField] private List<RamSO> RAM;
        [SerializeField] private List<DataShardSO> Shards;

        public Guid SourceId => SourceGateway?.Id ?? Guid.Empty;


        public int MaxCPUSlots => maxCPUSlots;
        public int MaxRAMSlots => maxRAMSlots;
        public int MaxDataShardSlots => maxDataShardSlots;

        public override Type ItemType => GetType();

        public IEnumerable<ICpu> CPUs => CPU.Cast<ICpu>();
        public IEnumerable<IRam> RAMs => RAM.Cast<IRam>();
        public IEnumerable<IDataShard> DataShards => Shards.Cast<IDataShard>();

    }

}
