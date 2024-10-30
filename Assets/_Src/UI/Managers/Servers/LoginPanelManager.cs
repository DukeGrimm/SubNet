using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Subnet.UI.Managers.Servers
{
    public class LoginPanelManager : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;
        private IServerOperationController _serverOperationController;
        private IGameState<EServerOperationState> _loginState;
        //UI Elements
        [SerializeField] private GameObject _loginPanel;
        [SerializeField] private TMP_Text _serverNameText;
        [SerializeField] private TMP_InputField _usernameInputField;
        [SerializeField] private TMP_InputField _passwordInputField;
        //GameData
        //--CachedServerData, Do We need this?
        private IServer serverCache;
        private string serverPassword;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverOperationManager);
            RequestService(out _serverOperationController);
            IsLoginPanelSet();
            IsServerNameTxtSet();
            IsUsernameInputFieldSet();
            IsPasswordInputFieldSet();
            if(_serverOperationController == null) Debug.LogError("LoginPanelManager: No ServerOperationController assigned");
            else
            {
                _serverOperationController.FindGameState(out _loginState, EServerOperationState.Connected);
            }
            if(_loginState == null) Debug.LogError("LoginPanelManager: Login State not found");
            else
            {
                SubscribeEvent(_loginState, GameStateEvents.OnStateEntered.ToString(), ConfigureLogin);
                SubscribeEvent(_loginState, GameStateEvents.OnStateExited.ToString(), HideLoginPanel);
            }
        }

        private void ConfigureLogin()
        {
            serverCache = null;
            serverCache = _serverOperationManager.GetServer();
            if(serverCache == null) Debug.LogError("LoginPanelManager: No Server Cached");
            else
            {
                _serverNameText.text = serverCache.Name;
                ShowLoginPanel();
            }
        }

        private void ShowLoginPanel()
        {
            _loginPanel.SetActive(true);
        }
        private void HideLoginPanel()
        {
            _loginPanel.SetActive(false);
        }
        //Helpers
        private bool IsLoginPanelSet()
        {
            if (_loginPanel != null) return true;
            Debug.LogError("LoginPanelManager: LoginPanel is not set");
            return false;
        }
        private bool IsServerNameTxtSet()
        {
            if (_serverNameText != null) return true;
            Debug.LogError("LoginPanelManager: ServerNameText is not set");
            return false;
        }
        private bool IsUsernameInputFieldSet()
        {
            if (_usernameInputField != null) return true;
            Debug.LogError("LoginPanelManager: UsernameInputField is not set");
            return false;
        }
        private bool IsPasswordInputFieldSet()
        {
            if (_passwordInputField != null) return true;
            Debug.LogError("LoginPanelManager: PasswordInputField is not set");
            return false;
        }

    }
}
