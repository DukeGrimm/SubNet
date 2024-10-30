using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;

namespace SubNet.Common.Structs.BasicTypes
{
    public struct IntRange
    {
        [OdinSerialize]
        [MinValue(1), MaxValue("@Max")]
        public int Min;
        [OdinSerialize]
        [MinValue("@Min")]
        public int Max;

        public IntRange(int min, int max)
        {
            Min = min;
            Max = max;
        }

        //public int RandomValue => UnityEngine.Random.Range(Min, Max);
        public int RandomValue() => UnityEngine.Random.Range(Min, Max);
    }
}
