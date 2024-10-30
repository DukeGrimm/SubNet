using SubNet.Common.Interfaces.Data.Missions;
using System;

namespace SubNet.Common.Interfaces.Game.Missions
{
    public interface IMissionTemplateManager
    {
        IMissionTemplate GetMissionTemplate(Guid id);
        IMissionTemplate GetRandomMissionTemplate(Random ran);
    }
}
