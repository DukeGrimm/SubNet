using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Data;
using SubNet.Common.Enum.Data.Servers;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Structs.Data;
using System;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Server", menuName = "Content/ServerSO", order = 1)]
    public class ServerSO : ScriptableEmber, IServer, IEmberObject
    {
        [SerializeField] private EServerType _serverType;
        [SerializeField] private IpAddress _address;
        [SerializeField] private CorpSO _corp;

        public override Type ItemType => GetType();


        public IpAddress Address => _address;

        public Guid CorpId => _corp.Id;

        public EServerType ServerType => _serverType;

        public IDataStorage Database => throw new NotImplementedException();

        public ServerSO() : base()
        {
            _name = "New Server";
            _serverType = EServerType.NULL;
            _address = new IpAddress();
            
        }
    }
}
