using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System;

namespace SubNet.Game.Managers.ServerOperations
{
    /// <summary>
    /// Handles changing states for Connection to server. Connected, Dashboard, Database, Marketplace, Logs, Disconnected
    /// Anything that is state dependent should attatch to the OnEnteredState of the relevent state.
    /// </summary>
    public class ServerOperationManager : EmberSingleton, IServerOperationManager
    {
        //Services
        private IServerOperationController _opsController;
        private IServerManager _serverManager;
        //Local Data
        private Guid connectedServer = Guid.Empty;
        private IServer cachedServer;
        //Properties
        public Guid ConnectedServerId => connectedServer;

        //Orchistrators
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _opsController);
            RequestService(out _serverManager);
        }
        //Methods
        public void ConnectToServer(Guid serverId)
        {
            //throw new NotImplementedException();
            connectedServer = serverId;
            _opsController.ChangeGameState(EServerOperationState.Connected);
        }

        public void LoginToServer(string password)
        {
            //CheckPassword Valid, Update later to return bool incase of failure
            _opsController.ChangeGameState(EServerOperationState.Dashboard);
        }

        public void DisconnectFromServer()
        {
            connectedServer = Guid.Empty;
            _opsController.ChangeGameState(EServerOperationState.Disconnected);
        }
        public void AccessDatabase()
        {
            _opsController.ChangeGameState(EServerOperationState.Database);
        }
        public void AccessMarkets()
        {
            _opsController.ChangeGameState(EServerOperationState.Markets);
        }
        public void AccessMissions()
        {
            _opsController.ChangeGameState(EServerOperationState.Missions);
        }

        //TODO: Hacking tools will call this when utilized to do something on the connected server.
        //This would be the spot to trigger traces and other counter-hacking mechanics.
        //This wouild also be the spot to change flags on the server to unlock any parts hidden behind hacking locks.
        public void UseHackingTool()
        {
            throw new NotImplementedException();
        }
        //Helpers
        public bool IsConnectedToServer() => connectedServer != Guid.Empty;
        public IServer GetServer() => _serverManager.GetServer(connectedServer);
    }
}
