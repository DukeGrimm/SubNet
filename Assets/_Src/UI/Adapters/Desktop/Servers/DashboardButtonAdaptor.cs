using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Desktop.Servers
{
    public class DashboardButtonAdaptor : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;    
        //Locals
        [SerializeField] private EServerOperationState _serverOperationState;
        [SerializeField] private Button _dashboardButton;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverOperationManager);
            if(IsDashboardButtonSet())
            {
                _dashboardButton.onClick.AddListener(OnDashboardButtonClicked);
            }
        }

        private void OnDashboardButtonClicked()
        {
            //TODO: Figure out a better approch to allowing this control to be dynamic for all dashboard buttons.
            switch(_serverOperationState)
            {
                case EServerOperationState.Disconnected:
                    _serverOperationManager.DisconnectFromServer();
                    break;
                case EServerOperationState.Database:
                    _serverOperationManager.AccessDatabase();
                    break;
                case EServerOperationState.Markets:
                    _serverOperationManager.AccessMarkets();
                    break;
                case EServerOperationState.Missions:
                    _serverOperationManager.AccessMissions();
                    break;
                default:
                    Debug.LogError("DashboardButtonAdaptor: Invalid Dashboard Button State");
                    break;
            }
        }

        //Helpers
        private bool IsDashboardButtonSet()
        {
            if (_dashboardButton == null && GetComponent<Button>())
            {
                _dashboardButton = GetComponent<Button>();
                if (_dashboardButton == null)
                {
                    Debug.LogError("DashboardButtonAdaptor: No DashboardButton assigned");
                }
            }
            return _dashboardButton != null;
        }
    }
}
