using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Enum.Data.Missions;
using System;

namespace SubNet.Common.Interfaces.Data.Missions
{
    public interface IMission : IEmberObject
    {
        Guid ClientId { get; }
        Guid TargetCorpId { get; }
        Guid MissionTemplateId { get; }
        Guid TargetServerId { get; }
        MissionTypeValues MissionType { get; }
        EMissionState MissionState { get; }
        Guid TargetDataId { get; }
        int RewardCredits { get; }
        int RewardRep { get; }
        DateTime ExpireTime { get; }

        void FailMission();
        void ExpireMission();
        void CompleteMission();

    }
}
