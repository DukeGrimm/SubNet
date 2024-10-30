using EmberToolkit.Common.DataTypes;
using EmberToolkit.Unity.Data;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using SubNet.Common.Enum.Data.Missions;
using SubNet.Common.Interfaces.Data.Missions;
using System;

namespace SubNet.Data.Missions
{
    public class Mission : EmberObject, IMission
    {
        [ShowInInspector, ReadOnly]
        private Guid clientId;
        [ShowInInspector, ReadOnly]
        private Guid targetId;
        [ShowInInspector, ReadOnly]
        private Guid missionTemplateId;
        [ShowInInspector, ReadOnly]
        private Guid targetServerId;
        [ShowInInspector, ReadOnly]
        private MissionTypeValues missionType = MissionTypeValues.NULL;
        [ShowInInspector, ReadOnly]
        private EMissionState missionState = EMissionState.NULL;
        [ShowInInspector, ReadOnly]
        private Guid targetDataId;
        [ShowInInspector, ReadOnly]
        private int rewardCredits;
        [ShowInInspector, ReadOnly]
        private int rewardRep;
        [ShowInInspector, ReadOnly]
        private UDateTime expireTime;

        public Guid ClientId => clientId;
        public Guid TargetCorpId => targetId;
        public Guid MissionTemplateId => missionTemplateId;
        public Guid TargetServerId => targetServerId;
        public MissionTypeValues MissionType => missionType;
        public EMissionState MissionState => missionState;
        public Guid TargetDataId => targetDataId;
        public int RewardCredits => rewardCredits;
        public int RewardRep => rewardRep;
        public DateTime ExpireTime => expireTime.DateTime;



        public override Type ItemType => GetType();

        public Mission() : base()
        { }
        [JsonConstructor]
        public Mission([JsonProperty("Name")] string name, [JsonProperty("ClientId")] Guid client, [JsonProperty("MissionTemplateId")] Guid template, [JsonProperty("TargetId")] Guid target, [JsonProperty("TargetServerId")] Guid targetServrer, Guid targetData, [JsonProperty("MissionType")] MissionTypeValues mType, [JsonProperty("MissionState")] EMissionState mState, [JsonProperty("RewardCredits")] int reward, [JsonProperty("RewardRep")] int rep, [JsonProperty("ExpireTime")] DateTime expire) : base(Guid.NewGuid(), name)
        {
            this.clientId = client;
            this.targetId = target;
            this.missionTemplateId = template;
            this.targetServerId = targetServrer;
            this.targetDataId = targetData;
            this.missionType = mType;
            this.missionState = mState;
            this.rewardCredits = reward;
            this.rewardRep = rep;
            this.expireTime = new UDateTime(expire);
        }

        public void ExpireMission()
        {
            missionState = EMissionState.Expired;
        }
        public void FailMission()
        {
            missionState = EMissionState.Failed;
        }
        public void CompleteMission()
        {
            missionState = EMissionState.Complete;
        }


    }
}
