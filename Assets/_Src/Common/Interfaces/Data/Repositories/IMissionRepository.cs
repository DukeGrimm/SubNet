using SubNet.Common.Interfaces.Data.Missions;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Repositories
{
    public interface IMissionRepository
    {
        //Gets
        IMission GetMission(Guid id);
        IEnumerable<IMission> GetAllMissions();
        IEnumerable<IMission> GetMissionsWhere(Func<IMission, bool> filter);
        //Sets
        void AddMission(IMission mission);
        void RemoveMission(Guid id);
        void UpdateMission(IMission mission);
        void AddMissions(IEnumerable<IMission> missions);
    }
}
