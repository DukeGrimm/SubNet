using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Corps;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Game.Corps;
using SubNet.Common.ScriptableObjects;
using SubNet.Data.Corps;
using SubNet.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SubNet.Game.Managers.Data
{

    public class CorpManager : EmberSingleton, ICorpManager
    {
        private IContentController _contentController;
        [ShowInInspector, ReadOnly]
        private Dictionary<Guid, ICorp> corpRepo = new Dictionary<Guid, ICorp>();

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _contentController);
            LoadCorpsFromResources();
        }


        void LoadCorpsFromResources()
        {
            ContentFactory<CorpSO, Corp> factoryMethod = (CorpSO corpSO) => new Corp(corpSO);
            Action<List<Corp>> callback = (List<Corp> corps) =>
            {
                // Handle the loaded objects
                foreach (var corp in corps)
                {
                    corpRepo.Add(corp.Id, corp);
                }
            };
            _contentController.LoadContentFromResources("Corps", factoryMethod, callback);
        }


        #region CRUD
        public ICorp GetCorp(Guid id) => corpRepo[id];
        public ICorp GetRandomCorp() => corpRepo.Values.ElementAt(UnityEngine.Random.Range(0, corpRepo.Count -1));
        public ICorp GetRandomCorpWhere(Func<ICorp, bool> filter) => GetCorpsWhere(filter).ElementAt(UnityEngine.Random.Range(0, corpRepo.Count -1));
        public IEnumerable<ICorp> GetAllCorps() => corpRepo.Values;
        public IEnumerable<ICorp> GetCorpsWhere(Func<ICorp, bool> filter) => corpRepo.Values.Where(filter);
        #endregion
    }
}
