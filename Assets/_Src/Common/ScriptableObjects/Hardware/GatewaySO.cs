using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Interfaces.Data.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects.Hardware
{
    [CreateAssetMenu(fileName = "New Gateway", menuName = "Content/Hardware/GatewaySO", order = 1)]
    public class GatewaySO : ScriptableEmber, IGatewayBase
    {
        [SerializeField] private int maxCPUSlots;
        [SerializeField] private int maxRAMSlots;
        [SerializeField] private int maxDataShardSlots;


        public int MaxCPUSlots => maxCPUSlots;
        public int MaxRAMSlots => maxRAMSlots;
        public int MaxDataShardSlots => maxDataShardSlots;

        public override Type ItemType => GetType();

    }
}
