using SubNet.Common.Interfaces.Data.Hardware;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects.Hardware
{
    [CreateAssetMenu(fileName = "New RAM", menuName = "Content/Hardware/RamSO", order = 1)]
    public class RamSO : ScriptableEmber, IRam
    {
        [SerializeField] private int size;
        public int Size => size;

        public override Type ItemType => GetType();
    }
}
