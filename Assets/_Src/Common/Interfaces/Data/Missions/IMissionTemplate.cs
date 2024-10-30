using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Enum.Data.Corps;
using SubNet.Common.Enum.Data.Missions;
using SubNet.Common.Structs.BasicTypes;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Missions
{
    public interface IMissionTemplate : IEmberObject
    {
        //EmberObject
        //Guid Id { get; }
        //Type ItemType { get; }
        //string Name { get; }
        MissionTypeValues MissionType { get; }
        string MissionBreifingTemplate { get; }
        List<ECorpClass> ValidTargetCorpClasses { get; }
        IntRange RewardCreditsRange { get; }
        int RewardRep { get; }


    }
}
