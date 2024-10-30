using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Enum.Data.Servers;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Subnet.UI.Managers.Servers
{
    public class DashboardManager : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;
        private IServerOperationController _serverOperationController;
        private IGameState<EServerOperationState> _dashboardState;
        //UI Elements
        [SerializeField] private GameObject _dashboardPanel;
        [SerializeField] private GameObject _MarketsBtn;
        [SerializeField] private GameObject _MissionsBtn;
        [SerializeField] private GameObject _DatabaseBtn;

        [SerializeField] private TMP_Text _ServerGreetingTxt;
        //Locals
        private static string _serverGreeting = "Welcome to {0}.";
        private IServer serverCache;
        
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverOperationManager);
            RequestService(out _serverOperationController);
            if(!_serverOperationController.FindGameState(out _dashboardState, EServerOperationState.Dashboard))
            {
                Debug.LogError("DashboardManager: Dashboard State not found");
            }
            else
            {
                SubscribeEvent(_dashboardState, GameStateEvents.OnStateEntered.ToString(), ShowDashboard);
                SubscribeEvent(_dashboardState, GameStateEvents.OnStateExited.ToString(), HideDashboard);
            }
            AdjustButtonsBasedOnServerType(EServerType.Mainframe);
        }

        private void ShowDashboard()
        {
            serverCache = _serverOperationManager.GetServer();
            if(serverCache == null) Debug.LogError("DashboardManager: No Server Cached");
            else
            {
                AdjustButtonsBasedOnServerType(serverCache.ServerType);
                UpdateServerGreeting();
            }
            if(IsDashboardPanelSet()) _dashboardPanel.SetActive(true);
        }
        private void HideDashboard() {
            if(IsDashboardPanelSet()) _dashboardPanel.SetActive(false);
        }

        private void AdjustButtonsBasedOnServerType(EServerType serverType)
        {
            if(serverType == EServerType.SubnetInternal)
            {
                _MarketsBtn.SetActive(true);
                _MissionsBtn.SetActive(true);
                _DatabaseBtn.SetActive(false);
            }
            else
            {
                _MarketsBtn.SetActive(false);
                _MissionsBtn.SetActive(false);
                _DatabaseBtn.SetActive(true);
            }

        }

        private void UpdateServerGreeting()
        {
            if (serverCache == null) Debug.LogError("DashboardManager: No Server Cached");
            else
            {
                _ServerGreetingTxt.text = string.Format(_serverGreeting, serverCache.Name);
            }
        }

        //Helpers
        private bool IsDashboardPanelSet() {
            if(_dashboardPanel == null)
            {
                Debug.LogError("DashboardManager: No Dashboard Panel assigned");
                return false;
            }
            return true;
        }
    }
}
