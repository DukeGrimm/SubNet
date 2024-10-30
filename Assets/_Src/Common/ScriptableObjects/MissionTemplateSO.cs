using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SubNet.Common.Enum.Data.Corps;
using SubNet.Common.Enum.Data.Missions;
using SubNet.Common.Interfaces.Data.Missions;
using SubNet.Common.Structs.BasicTypes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Common.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Mission Template", menuName = "Content/MissionTemplate", order = 1)]
    public class MissionTemplateSO : ScriptableEmber, IMissionTemplate
    {
        [OdinSerialize] private MissionTypeValues missionType;
        [Title("Mission Breifing", bold: false)]
        [HideLabel, MultiLineProperty(10)]
        [OdinSerialize] private string missionBreifingTemplate;
        [OdinSerialize] private List<ECorpClass> validTargetCorpClasses = new List<ECorpClass>();
        [OdinSerialize] private IntRange rewardCreditsRange;
        [OdinSerialize] private int rewardRep;

        public override Type ItemType => GetType();

        public MissionTypeValues MissionType => missionType;

        public string MissionBreifingTemplate => missionBreifingTemplate;

        public List<ECorpClass> ValidTargetCorpClasses => validTargetCorpClasses;

        public IntRange RewardCreditsRange => rewardCreditsRange;

        public int RewardRep => rewardRep;
    }
}
