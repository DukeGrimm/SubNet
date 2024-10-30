using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Repositories
{
    public interface IDataStorageRepository
    {
        //Gets
        IDataStorage GetDataStorage(Guid id);
        IEnumerable<IDataStorage> GetAllDataStorage();
        IEnumerable<IDataStorage> GetDataStorageWhere(Func<IDataStorage, bool> filter);
        //Sets
        void AddDataStorage(IDataStorage storage);
        void RemoveServer(Guid id);
        void UpdateServer(IDataStorage storage);
        void AddServers(IEnumerable<IDataStorage> storages);

    }
}
