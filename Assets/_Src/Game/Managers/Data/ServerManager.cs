using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.DataStorage;
using SubNet.Common.Interfaces.Data.Repositories;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.ScriptableObjects;
using SubNet.Data.Repositories;
using SubNet.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubNet.Game.Managers.Data
{
    public class ServerManager : EmberSingleton, IServerManager
    {
        private IContentController _contentLoaderManager;
        private IDataStorageManager _dataStorageManager;

        [ShowInInspector, ReadOnly]
        private IServerRepository _serverRepository;





        protected override void Awake()
        {
            base.Awake();
            RequestService(out _contentLoaderManager);
            RequestService(out _dataStorageManager);
            _serverRepository = new ServerRepository(GetService<ISaveLoadEvents>(), false);
            LoadServersFromResources();

        }

        protected override void OnDestroy() {
            base.OnDestroy();
            _serverRepository = null;
        }

        void LoadServersFromResources()
        {
            ContentFactory<ServerSO, Server> factoryMethod = (ServerSO serverSO) => new Server(serverSO);
            Action<List<Server>> callback = (List<Server> servers) =>
            {
                // Handle the loaded servers, e.g., add them to the repository
                foreach (var server in servers)
                {
                    _serverRepository.AddServer(server);
                }
                SetUpServerDataStorage();
            };

            // Assuming contentLoaderManager is an instance of ContentLoaderManager
            _contentLoaderManager.LoadContentFromResources("Servers", factoryMethod, callback);
    
        }

        private void SetUpServerDataStorage()
        {
            IEnumerable<IServer> servers = _serverRepository.GetAllServers();
            foreach (var server in servers)
            {
                IDataStorage dataStorage = new DataStorage(server.Id);
                dataStorage.CreateRandomQuads(10, server.Name.Substring(0, 3));
                _dataStorageManager.CreateNewDataStorage(dataStorage);
            }

        }




        #region CRUD
        public IServer GetServer(Guid id) => _serverRepository.GetServer(id);
        public IEnumerable<IServer> GetAllServers() => _serverRepository.GetAllServers();
        public IEnumerable<IServer> GetServersWhere(Func<IServer, bool> filter) => _serverRepository.GetServersWhere(filter);
        public void UpdateServer(IServer server) => _serverRepository.UpdateServer(server);
        public IServer GetRandomServer()
        {
            IEnumerable<IServer> servers = _serverRepository.GetAllServers();
            return servers.ElementAt(UnityEngine.Random.Range(0, servers.Count()-1));
        }

        public IServer GetRandomServerWhere(Func<IServer, bool> filter)
        {
            IEnumerable<IServer> servers = _serverRepository.GetServersWhere(filter);
            return servers.ElementAt(UnityEngine.Random.Range(0, servers.Count()-1));
        }
        #endregion
    }
}
