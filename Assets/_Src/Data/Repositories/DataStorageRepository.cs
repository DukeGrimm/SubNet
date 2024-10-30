using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.DataManagement.Repositories;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.Repositories;
using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.Data.Repositories
{
    public class DataStorageRepository : Repository<IDataStorage>, IDataStorageRepository
    {
        public DataStorageRepository(ISaveLoadEvents saveLoadEvents, bool shouldSave = true) : base(saveLoadEvents, shouldSave)
        {
        }

        public void AddDataStorage(IDataStorage storage) => Add(storage);

        public void AddServers(IEnumerable<IDataStorage> storages)
        {
           foreach (var storage in storages)
            {
                Add(storage);
            }
        }

        public IEnumerable<IDataStorage> GetAllDataStorage() => GetAll();

        public IDataStorage GetDataStorage(Guid id) => Get(id);

        public IEnumerable<IDataStorage> GetDataStorageWhere(Func<IDataStorage, bool> filter) => GetAll().Where(filter);

        public void RemoveServer(Guid id) => Delete(id);

        public void UpdateServer(IDataStorage storage) { Update(storage); }
    }
}
