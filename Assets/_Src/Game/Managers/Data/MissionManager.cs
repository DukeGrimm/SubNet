using EmberToolkit.Common.Attributes;
using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Controllers;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Time;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SubNet.Common.Enum.Data.Missions;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Corps;
using SubNet.Common.Interfaces.Data.DataStorage;
using SubNet.Common.Interfaces.Data.Missions;
using SubNet.Common.Interfaces.Data.Repositories;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.Corps;
using SubNet.Common.Interfaces.Game.Emails;
using SubNet.Common.Interfaces.Game.Missions;
using SubNet.Common.Interfaces.Game.Player;
using SubNet.Common.Structs.Data.Servers;
using SubNet.Data.Missions;
using SubNet.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubNet.Game.Managers.Data
{
    public class MissionManager : EmberSingleton, IMissionManager
    {
        private ITimeManager _timeManager;
        private ITimeManagerEvents _timeEvents;
        private IEmailManager _emailManager;
        private IWalletManager _walletManager;
        private IMissionRepository _missionRepository;
        private IMissionTemplateManager _missionTemplateManager;
        private ICorpManager _corpManager;
        private IServerManager _serverManager;
        private IDataStorageManager _dataStorageManager;
        private IGameStateManager<SubnetGameStates> _subnetGameStates;


        [OdinSerialize]
        private int _MaxMissionsOnBoard = 10;
        public bool HasActiveMissions => _missionRepository.GetMissionsWhere(m => m.MissionState == EMissionState.Active).Any();

        public bool HasCompletedMissions => _missionRepository.GetMissionsWhere(m => m.MissionState == EMissionState.Complete).Any();

        [ShowInInspector, ReadOnly] private IEnumerable<IMission> _ListMissions;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _timeManager);
            RequestService(out _emailManager);
            RequestService(out _walletManager);
            RequestService(out _missionTemplateManager);
            RequestService(out _corpManager);
            RequestService(out _serverManager);
            RequestService(out _dataStorageManager);
            RequestService(out _timeEvents);
            RequestService(out _subnetGameStates);
            _missionRepository = new MissionRepository(GetService<ISaveLoadEvents>());
            _timeEvents.OnDateUpdated += CheckForExpiredAndFailedMissions;

            _subnetGameStates.SubscribeToStateEvent(SubnetGameStates.Desktop, EmberToolkit.Common.Enum.Game.GameStateEvents.OnStateEntered, FillBoardWithMissions);

        }

        private void FillBoardWithMissions()
        {
            while (_missionRepository.GetMissionsWhere(m => m.MissionState == EMissionState.New).Count() < _MaxMissionsOnBoard)
            {
                IMission newMission = GenerateMission();
                _missionRepository.AddMission(newMission);
            }
            _ListMissions = _missionRepository.GetAllMissions();
        }

        private IMission GenerateMission()
        {
            //Get a random mission template
            IMissionTemplate missionTemplate = _missionTemplateManager.GetRandomMissionTemplate(new Random());
            //Create a new mission from the template
            ICorp client = _corpManager.GetRandomCorp();
            ICorp target = _corpManager.GetRandomCorpWhere(c => c != client);
            IServer targetServer = _serverManager.GetRandomServerWhere(s => s.CorpId == target.Id);
            IDataStorage targetStore = _dataStorageManager.GetDataStorage(targetServer.Id);
            IQuadObject targetQuad = targetStore.GetRandomQuad();
            MissionTypeValues nMissionType = MissionTypeValues.Copy;
            int nReward = missionTemplate.RewardCreditsRange.RandomValue();
            int nRepReward = missionTemplate.RewardRep;
            DateTime expireOn = _timeManager.InGameTime.AddHours(12); 
            IMission newMission = new Mission(missionTemplate.Name, client.Id, missionTemplate.Id, target.Id, targetServer.Id, targetQuad.Id, nMissionType, EMissionState.New, nReward, nRepReward, expireOn);
            return newMission;
        }

        /// <summary>
        /// Check for mission in repo that have expired and are active or new. If they are active, fail them. If they are new, expire them.
        /// </summary>
        /// <param name="curTime"></param>
        private void CheckForExpiredAndFailedMissions(DateTime curTime)
        {
            if(_missionRepository.GetMissionsWhere(m=> m.ExpireTime < curTime && m.MissionState == EMissionState.New || m.MissionState == EMissionState.Active).Any())
            {
              foreach(IMission mission in _missionRepository.GetMissionsWhere(m=> m.ExpireTime < curTime))
              {
                    if (mission.MissionState == EMissionState.Active) FailMission(mission);
                    else if (mission.MissionState == EMissionState.New) ExpireMission(mission); 
              }
            }   
        }

        #region CRUD

        //**Complete Mission**
        public void CompleteMission(Guid missionId) => CompleteMission(_missionRepository.GetMission(missionId));
        private void CompleteMission(IMission missh)
        {
            missh.CompleteMission();
            //Do other stuff like send complete email, change rep etc.
        }
        //**Fail Mission**
        public void FailMission(Guid missionId) => FailMission(_missionRepository.GetMission(missionId));
        private void FailMission(IMission missh)
        {
            missh.FailMission();
            //Do other stuff like send fail email, change rep etc.
        }

        //**Expire Mission**
        //This happens when a mission on the board is not accepted and the time runs out.
        public void ExpireMission(IMission missh) => missh.ExpireMission();

        public IEnumerable<IMission> GetActiveMissions()
        {
            return _missionRepository.GetMissionsWhere(m => m.MissionState == EMissionState.Active);
        }

        public IEnumerable<IMission> GetAllMissions()
        {
            return _missionRepository.GetAllMissions();
        }

        public IEnumerable<IMission> GetCompletedMissions()
        {
            return _missionRepository.GetMissionsWhere(m => m.MissionState == EMissionState.Complete);
        }

        public IMission GetMission(Guid missionId)
        {
            return _missionRepository.GetMission(missionId);
        }

        public IEnumerable<IMission> GetMissionsWhere(Func<IMission, bool> predicate)
        {
            return _missionRepository.GetMissionsWhere(predicate);
        }

        public void RemoveMission(Guid missionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
