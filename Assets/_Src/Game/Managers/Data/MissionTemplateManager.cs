using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.Missions;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.Missions;
using SubNet.Common.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubNet.Game.Managers.Data
{

    public class MissionTemplateManager : EmberSingleton, IMissionTemplateManager
    {
        //Services
        private IContentController _contentController;

        //Local Dict
        [ShowInInspector, ReadOnly]
        private Dictionary<Guid, IMissionTemplate> missionTemplates = new Dictionary<Guid, IMissionTemplate>();
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _contentController);
            LoadMissionTemplates();
        }

        void LoadMissionTemplates()
        {
            _contentController.LoadContentFromResources<MissionTemplateSO, IMissionTemplate>("MissionTemplates", missTempSO => missTempSO as IMissionTemplate, HandleLoadedTemplates);
        }

        void HandleLoadedTemplates(List<IMissionTemplate> missionTemplates)
        {
            foreach (var missionTemplate in missionTemplates)
            {
                this.missionTemplates.Add(missionTemplate.Id, missionTemplate);
            }
        }

        #region CRUD
        public IMissionTemplate GetMissionTemplate(Guid id)
        {
            if (missionTemplates.ContainsKey(id))
            {
                return missionTemplates[id];
            }
            return null;
        }

        public IMissionTemplate GetRandomMissionTemplate(Random ran)
        {
            return missionTemplates.Values.ElementAt(ran.Next(0, missionTemplates.Count));
        }
        #endregion
    }
}
