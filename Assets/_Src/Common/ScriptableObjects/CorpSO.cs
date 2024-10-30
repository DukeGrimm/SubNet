using SubNet.Common.Enum.Data.Corps;
using SubNet.Common.Interfaces.Corps;
using SubNet.Common.ScriptableObjects;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Corp", menuName = "Content/CorpSO", order = 1)]
    public class CorpSO : ScriptableEmber, ICorp
    {
        [SerializeField] private ECorpClass _class;
        public ECorpClass Class => _class;
        public override Type ItemType => GetType();
    }
}
