using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects
{
    public abstract class ScriptableEmber : SerializedScriptableObject, IEmberObject
    {
       [OdinSerialize] protected Guid _id;
       [OdinSerialize] protected string _name;
        public Guid Id => _id;

        public abstract Type ItemType { get; }

        public string Name => _name;

        public ScriptableEmber()
        {
            _id = Guid.NewGuid();

        }
    }
}
