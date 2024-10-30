using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Unity.Behaviours;
using Subnet.UI.Adapters.Desktop.Servers;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Subnet.UI.Managers.Servers
{
    public class ServerListManager : EmberBehaviour
    {
        //Services
        private IServerManager _serverManager;
        private IServerOperationController _serverOperationController;
        private IGameState<EServerOperationState> disconnectedState;
        //UI Elements
        [SerializeField] private GameObject serverListHandle;
        [SerializeField] private GameObject serverListObject;
        [SerializeField] private TMP_InputField filterField;
        //UI Prefabs
        [SerializeField] private GameObject serverItemPrefab;
        //cached Server List Items
        private List<ServerListItemAdapter> serverListItems = new List<ServerListItemAdapter>();

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverManager);
            IsListObjectSet();
            IsFilterFieldSet();
            IsServerItemPrefabSet();
            RequestService(out _serverOperationController);
            if (_serverOperationController == null) Debug.LogError("ServerListManager: No ServerOperationController assigned");
            else
            {
                _serverOperationController.FindGameState(out disconnectedState, EServerOperationState.Disconnected);
            }
            if(disconnectedState == null) Debug.LogError("ServerListManager: Disconnected State not found");
            else
            {
                SubscribeEvent(disconnectedState, GameStateEvents.OnStateEntered.ToString(), ShowList);
                SubscribeEvent(disconnectedState, GameStateEvents.OnStateExited.ToString(), HideList);
            }

        }
        protected void Start()
        {
            InitializeServerList();
            BindFilter();
        }

        private void BindFilter()
        {
            if (IsFilterFieldSet())
            {
                filterField.onValueChanged.AddListener(delegate { FilterList(); });
            }
        }

        private void InitializeServerList()
        {
            ClearList();
            IEnumerable<IServer> servers = _serverManager.GetAllServers();
            foreach (IServer server in servers)
            {
                GameObject newServerItem = Instantiate(serverItemPrefab, serverListObject.transform);
                ServerListItemAdapter serverItemAdapter = newServerItem.GetComponent<ServerListItemAdapter>();
                if (serverItemAdapter == null)
                {
                    Debug.LogError("ServerListManager: ServerItemPrefab does not have ServerListItemAdapter component");
                    return;
                }
                else
                {
                    //Change to IP when IP is finished being implemented.
                    serverItemAdapter.SetUpServerListItem(server.Address.ToString(), server.Name, server.Id);
                    serverListItems.Add(serverItemAdapter);
                }
                
            }

        }

        private void FilterList()
        {
            if (IsFilterFieldSet() && !string.IsNullOrEmpty(filterField.text))
            {
                foreach (ServerListItemAdapter item in serverListItems)
                {
                    if (item.ServerName.ToLower().Contains(filterField.text.ToLower()))
                    {
                        item.gameObject.SetActive(true);
                    }
                    else
                    {
                        item.gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                foreach (ServerListItemAdapter item in serverListItems)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }


        //Helpers
        private void HideList()
        {
           SetListActiveState(false);
        }
        private void ShowList()
        {
            SetListActiveState(true);
        }
        private void SetListActiveState(bool state)
        {
            if(IsServerHandleSet()) serverListHandle.SetActive(state);
        }
        private bool IsServerHandleSet()
        {
            if (serverListHandle == null) Debug.LogError("ServerListManager: No ServerListHandle assigned");
            return serverListHandle != null;
        }
        private bool IsListObjectSet()
        {
            if (serverListObject == null) Debug.LogError("ServerListManager: No ServerList Gameobject assigned");
            return serverListObject != null;
        }
        private bool IsFilterFieldSet()
        {
            if (filterField == null) Debug.LogError("ServerListManager: No FilterField assigned");
            return filterField != null;
        }
        private bool IsServerItemPrefabSet()
        {
           if (serverItemPrefab == null) Debug.LogError("ServerListManager: No ServerItemPrefab assigned");
            return serverItemPrefab != null;
        }
        private void ClearList() {
            if(serverListItems.Count == 0) return;
            foreach (ServerListItemAdapter item in serverListItems)
            {
                Destroy(item.gameObject);
            }
            serverListItems.Clear();
        }

    }
}
