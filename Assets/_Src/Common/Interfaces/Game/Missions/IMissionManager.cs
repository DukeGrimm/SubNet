using SubNet.Common.Interfaces.Data.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game.Missions
{
    public interface IMissionManager
    {
        bool HasActiveMissions { get; }
        bool HasCompletedMissions { get; }

        //void AddMission(IMission mission);
        void RemoveMission(Guid missionId);
        void CompleteMission(Guid missionId);
        void FailMission(Guid missionId);

        IMission GetMission(Guid missionId);
        IEnumerable<IMission> GetAllMissions();
        IEnumerable<IMission> GetActiveMissions();
        IEnumerable<IMission> GetCompletedMissions();
        IEnumerable<IMission> GetMissionsWhere(Func<IMission, bool> predicate);
    }
}
