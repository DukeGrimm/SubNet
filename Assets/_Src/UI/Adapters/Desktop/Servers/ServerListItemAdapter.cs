using EmberToolkit.Unity.Behaviours;
using Sirenix.Serialization;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Desktop.Servers
{
    public class ServerListItemAdapter : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;
        //UI Elements
        [SerializeField] private Button _serverItemButton;
        [SerializeField] private TMP_Text serverIpTxt;
        [SerializeField] private TMP_Text serverNameTxt;
        //Game Data\
        [SerializeField] private string serverIp;
        [SerializeField] private string serverName;
        [OdinSerialize] private Guid serverId;

        //Public Properties
        public string ServerIp => serverIpTxt.text;
        public string ServerName => serverNameTxt.text;
        public Guid ServerId => serverId;

        protected override void Awake()
        {
            base.Awake();

 
        }

        public void SetUpServerListItem(string serverIp, string serverName, Guid serverId)
        {
            this.serverIp = serverIp;
            this.serverName = serverName;
            if (IsServerIpTxtSet()) serverIpTxt.text = serverIp;
            if (IsServerNameTxtSet()) serverNameTxt.text = serverName;
            this.serverId = serverId;
            RequestService(out _serverOperationManager);
            if (_serverOperationManager == null) Debug.LogError("ServerListItemAdapter: No ServerOperationManager assigned");
            else if (IsServerItemButtonSet() && serverId != Guid.Empty)
            {
                _serverItemButton.onClick.AddListener(() => _serverOperationManager.ConnectToServer(serverId));
            }
        }
        //Helpers
        private bool IsServerItemButtonSet()
        {
            if (_serverItemButton == null) Debug.LogError("ServerListItemAdapter: No ServerItemButton assigned");
            return _serverItemButton != null;
        }   
        private bool IsServerIpTxtSet()
        {
            if (serverIpTxt == null) Debug.LogError("ServerListItemAdapter: No ServerIpTxt assigned");
            return serverIpTxt != null;
        }
        private bool IsServerNameTxtSet()
        {
            if (serverNameTxt == null) Debug.LogError("ServerListItemAdapter: No ServerNameTxt assigned");
            return serverNameTxt != null;
        }
        private bool IsServerIdSet()
        {
            if (serverId == Guid.Empty) Debug.LogError("ServerListItemAdapter: No ServerId");
            return serverId != Guid.Empty;
        }
    }
}
