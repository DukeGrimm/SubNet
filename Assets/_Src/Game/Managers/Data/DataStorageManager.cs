using EmberToolkit.Common.Attributes;
using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.DataStorage;
using SubNet.Common.Interfaces.Data.Repositories;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Data.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Game.Managers.Data
{
    public class DataStorageManager : EmberSingleton, IDataStorageManager
    {
        //Services

        //Repos
        [ShowInInspector]
        private IDataStorageRepository _dataStorageRepository;


        //Locals
        protected override void Awake()
        {
            base.Awake();
            _dataStorageRepository = new DataStorageRepository(GetService<ISaveLoadEvents>());
        }

        public bool CreateNewDataStorage(IDataStorage dataStorage)
        {
            _dataStorageRepository.AddDataStorage(dataStorage);
            return true;
        }

        public IDataStorage GetDataStorage(Guid quadId) => _dataStorageRepository.GetDataStorage(quadId);


    }
}
