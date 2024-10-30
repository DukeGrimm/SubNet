using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Subnet.UI.Managers.Servers
{
    public class DatashardManager : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;
        private IServerOperationController _controller;
        private IGameState<EServerOperationState> _databaseState;
        //UI Elements
        [SerializeField] GameObject _databaseUiPanel;
        //Locals

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverOperationManager);
            RequestService(out _controller);
        }
    }
}
