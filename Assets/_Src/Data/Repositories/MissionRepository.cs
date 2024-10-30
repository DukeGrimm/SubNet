using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.DataManagement.Repositories;
using SubNet.Common.Interfaces.Data.Missions;
using SubNet.Common.Interfaces.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.Repositories
{
    public class MissionRepository : Repository<IMission>, IMissionRepository
    {
        public MissionRepository(ISaveLoadEvents saveLoadEvents, bool shouldSave = true) : base(saveLoadEvents, shouldSave)
        {
        }

        public void AddMission(IMission mission)
        {
            this.Add(mission);
        }

        public void AddMissions(IEnumerable<IMission> missions)
        {
            foreach(IMission mission in missions)
            {
                this.Add(mission);
            }
        }

        public IEnumerable<IMission> GetAllMissions()
        {
            return this.GetAll();
        }

        public IMission GetMission(Guid id)
        {
            return this.Get(id);
        }

        public IEnumerable<IMission> GetMissionsWhere(Func<IMission, bool> filter)
        {
            return this.GetWhere(filter);
        }

        public void RemoveMission(Guid id)
        {
            this.Delete(id);
        }

        public void UpdateMission(IMission mission)
        {
            this.Update(mission);
        }
    }
}
