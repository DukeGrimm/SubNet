using SubNet.Common.Interfaces.Data.Hardware;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects.Hardware
{
    [CreateAssetMenu(fileName = "New Cpu", menuName = "Content/Hardware/CpuSO", order = 1)]
    public class CpuSO : ScriptableEmber, ICpu
    {
        [SerializeField] private int speed;
        // Start is called before the first frame update
        public override Type ItemType => typeof(CpuSO);

        public int Speed => speed;
    }
}
