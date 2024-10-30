using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game
{
    public interface IServerManager
    {
        //Gets
        IServer GetServer(Guid id);
        IEnumerable<IServer> GetAllServers();
        IEnumerable<IServer> GetServersWhere(Func<IServer, bool> filter);
        IServer GetRandomServer();
        IServer GetRandomServerWhere(Func<IServer, bool> filter);
        //Sets
        void UpdateServer(IServer server);
    }
}
