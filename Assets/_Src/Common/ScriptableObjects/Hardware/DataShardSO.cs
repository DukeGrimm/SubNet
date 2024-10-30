using SubNet.Common.Interfaces.Data.Hardware;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects.Hardware
{
    [CreateAssetMenu(fileName = "New Datashard", menuName = "Content/Hardware/DataShardSO", order = 1)]
    public class DataShardSO : ScriptableEmber, IDataShard
    {
        [SerializeField] private int size;
        public int Size => size;

        public override Type ItemType => GetType();
    }
}
