using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game.ServerOperations
{
    public interface IServerOperationManager
    {
        void ConnectToServer(Guid serverId);
        void DisconnectFromServer();
        void LoginToServer(string password);
        void AccessDatabase();
        void AccessMarkets();
        void AccessMissions();
        bool IsConnectedToServer();
        Guid ConnectedServerId { get; }
        void UseHackingTool();
        IServer GetServer();

    }
}
