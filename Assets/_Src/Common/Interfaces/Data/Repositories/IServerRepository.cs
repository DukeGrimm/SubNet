using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Repositories
{
    public interface IServerRepository
    {
        //Gets
        IServer GetServer(Guid id);
        IEnumerable<IServer> GetAllServers();
        IEnumerable<IServer> GetServersWhere(Func<IServer, bool> filter);
        //Sets
        void AddServer(IServer server);
        void RemoveServer(Guid id);
        void UpdateServer(IServer server);
        void AddServers(IEnumerable<IServer> servers);

    }
}
