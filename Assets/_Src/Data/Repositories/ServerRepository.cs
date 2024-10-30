using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.DataManagement.Repositories;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.Repositories;
using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;

namespace SubNet.Data.Repositories
{
    public class ServerRepository : Repository<IServer>, IServerRepository
    {
        [ShowInInspector, ReadOnly] private Dictionary<Guid, IServer> serverList => _entities;
        public ServerRepository(ISaveLoadEvents saveLoadEvents, bool shouldSave = false) : base(saveLoadEvents, shouldSave)
        {

        }

        public void AddServer(IServer server) => Add(server);

        public void AddServers(IEnumerable<IServer> servers)
        {
            foreach(IServer server in servers)
            {
                AddServer(server);
            }
        }

        public IServer GetServer(Guid id) => Get(id);
        public IEnumerable<IServer> GetAllServers() => GetAll();

        public IEnumerable<IServer> GetServersWhere(Func<IServer, bool> filter) => GetWhere(filter);

        public void RemoveServer(Guid id) => Delete(id);

        public void UpdateServer(IServer server) => Update(server);
    }
}
