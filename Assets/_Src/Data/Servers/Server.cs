using EmberToolkit.Unity.Data;
using Sirenix.OdinInspector;
using SubNet.Common.Enum.Data.Servers;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.ScriptableObjects;
using SubNet.Common.Structs.Data;
using System;

namespace SubNet.Data.Servers
{
    public class Server : EmberObject, IServer
    {
        [ShowInInspector, ReadOnly]
        private Guid corpId;
        [ShowInInspector, ReadOnly]
        private EServerType serverType;
        [ShowInInspector]
        private IpAddress address;
        public Guid CorpId => corpId;
        public EServerType ServerType => serverType;
        public IpAddress Address => address;

        public override Type ItemType => GetType();

        public Server() { }
        public Server(IpAddress ipAddress, string sName, Guid corpInputId, EServerType newServerType) : base(sName)
        {
            corpId = corpInputId;
            address = ipAddress;
            serverType = newServerType;

        }

        public Server(ServerSO serverSO) : base(serverSO.Id, serverSO.Name)
        {
            corpId = serverSO.CorpId;
            serverType = serverSO.ServerType;
            address = serverSO.Address;
            //database = new DataStorage(100);
        }
        public Server(IServer server) : base(server.Id, server.Name)
        {
            corpId = server.CorpId;
            serverType = server.ServerType;
            address = server.Address;
            //database = new DataStorage(100);
        }
    }
}
