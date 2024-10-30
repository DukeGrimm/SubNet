using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Enum.Data.Servers;
using SubNet.Common.Structs.Data;
using System;

namespace SubNet.Common.Interfaces.Data.Servers
{
    public interface IServer : IEmberObject
    {
        IpAddress Address { get; }
        Guid CorpId { get; }
        EServerType ServerType { get; }
        //IDataStorage Database { get; }
    }
}
