using EmberToolkit.Common.Attributes;
using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Unity.Behaviours;
using Sirenix.Serialization;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Data.Hardware;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game.Hardware;
using SubNet.Common.ScriptableObjects.Hardware;
using SubNet.Data.Hardware;
using SubNet.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SubNet.Game.Managers.Data
{
  /// <summary>
  /// Stores Player's Gateway and DataStorage Data
  /// Provides methods to add and remove hardware components from the gateway
  /// Provides Access to DataStorage
  /// </summary>
    public class GatewayManager : EmberSingleton, IGatewayManager
    {
        private IHardwareManager _hardwareManager;
        private IGameStateManager<SubnetGameStates> _gameStateManager;
        private IGameState<SubnetGameStates> _mainMenu;

        [OdinSerialize] private GatewayBuiltSO DefaultGateway;


        [OdinSerialize][SaveField] private Gateway activeGateway;
        [OdinSerialize][SaveField] private IDataStorage gatewayData;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _hardwareManager);
            RequestService(out _gameStateManager);
            _gameStateManager.FindGameState(out _mainMenu, SubnetGameStates.MainMenu);
            //Construct Default Gateway and Datastorage
            SubscribeEvent(_mainMenu, nameof(_mainMenu.OnStateEntered), BuildDefaultGateway);
        }

        private void BuildDefaultGateway()
        {
            activeGateway = new Gateway(_hardwareManager.GetGateway(DefaultGateway.SourceId));
            foreach (ICpu cpu in DefaultGateway.CPUs)
            {
                AddCpu(cpu);
            }
            foreach (IRam ram in DefaultGateway.RAMs)
            {
                AddRam(ram);
            }
            foreach (IDataShard dataShard in DefaultGateway.DataShards)
            {
                AddDataShard(dataShard);
            }
            gatewayData = new DataStorage(GatewayDataShardSize);
        }

        /// <summary>
        /// Transfer all hardware components from the old gateway to the new gateway.
        /// </summary>
        /// <param name="newGateway"></param>

        public void UpgradeGateway(IGatewayBase newGateway)
        {
            Gateway standUpGateway = new Gateway(newGateway);
            foreach (Guid cpu in activeGateway.Cpus)
            {
                standUpGateway.AddCpu(cpu);
            }
            foreach (Guid ram in activeGateway.Rams)
            {
                standUpGateway.AddRam(ram);
            }
            foreach (Guid dataShard in activeGateway.DataShards)
            {
                standUpGateway.AddDataShard(dataShard);
            }
            activeGateway = standUpGateway;
        }

        #region Getters
        public IDataStorage GetLocalGatewayData() => gatewayData;
        public int GatewayCpuSpeed => _hardwareManager.GetTotalCPUSpeed(activeGateway.Cpus);
        public int GatewayRamSize => _hardwareManager.GetTotalRAMSize(activeGateway.Rams);
        public int GatewayDataShardSize => _hardwareManager.GetTotalDataShardSize(activeGateway.DataShards);
        public IEnumerable<ICpu> GetCpus() => _hardwareManager.GetCPUs(activeGateway.Cpus);
        public IEnumerable<IRam> GetRams() => _hardwareManager.GetRAMs(activeGateway.Rams);
        public IEnumerable<IDataShard> GetDataShards() => _hardwareManager.GetDataShards(activeGateway.DataShards);
        #endregion

        #region AddRemove Hardware Components
        public void AddCpu(ICpu cpu)
        {
            if (activeGateway.Cpus.Count() < activeGateway.MaxCPUSlots)
            {
                activeGateway.AddCpu(cpu);
            }
        }
        public void RemoveCpu(ICpu cpu) { activeGateway.RemoveCpu(cpu); }
        public void AddRam(IRam ram)
        {
            if (activeGateway.Rams.Count() < activeGateway.MaxRAMSlots)
            {
                activeGateway.AddRam(ram);
            }
        }
        public void RemoveRam(IRam ram) { activeGateway.RemoveRam(ram); }
        public void AddDataShard(IDataShard dataShard)
        {
            if (activeGateway.DataShards.Count() < activeGateway.MaxDataShardSlots)
            {
                activeGateway.AddDataShard(dataShard);
                if(gatewayData != null)
                    gatewayData.AddQuads(dataShard.Size);
            }
        }
        public void RemoveDataShard(IDataShard dataShard) { activeGateway.RemoveDataShard(dataShard); }
        #endregion


    }
}
