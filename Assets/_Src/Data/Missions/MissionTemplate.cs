using EmberToolkit.Unity.Data;
using Newtonsoft.Json;
using SubNet.Common.Enum.Data.Corps;
using SubNet.Common.Enum.Data.Missions;
using SubNet.Common.Interfaces.Data.Missions;
using SubNet.Common.ScriptableObjects;
using SubNet.Common.Structs.BasicTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.Missions
{
    public class MissionTemplate : EmberObject, IMissionTemplate
    {
        private MissionTypeValues missionType;
        private string missionBreifingTemplate;
        private List<ECorpClass> validTargetCorpClasses = new List<ECorpClass>();
        private IntRange rewardCreditsRange;
        private int rewardRep;
        public override Type ItemType => GetType();

        public MissionTypeValues MissionType => missionType;

        public string MissionBreifingTemplate => missionBreifingTemplate;

        public List<ECorpClass> ValidTargetCorpClasses => validTargetCorpClasses;

        public IntRange RewardCreditsRange => rewardCreditsRange;

        public int RewardRep => rewardRep;

        public MissionTemplate() { }
        public MissionTemplate(MissionTemplateSO missionTemplateSO) : base(missionTemplateSO.Id, missionTemplateSO.Name)
        {
            missionType = missionTemplateSO.MissionType;
            missionBreifingTemplate = missionTemplateSO.MissionBreifingTemplate;
            validTargetCorpClasses = missionTemplateSO.ValidTargetCorpClasses;
            rewardCreditsRange = missionTemplateSO.RewardCreditsRange;
            rewardRep = missionTemplateSO.RewardRep;
        }

        public MissionTemplate(IMissionTemplate missionTemplate) : base(missionTemplate.Id, missionTemplate.Name)
        {
            missionType = missionTemplate.MissionType;
            missionBreifingTemplate = missionTemplate.MissionBreifingTemplate;
            validTargetCorpClasses = missionTemplate.ValidTargetCorpClasses;
            rewardCreditsRange = missionTemplate.RewardCreditsRange;
            rewardRep = missionTemplate.RewardRep;
        }
    }
}
