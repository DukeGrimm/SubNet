using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.DataStorage
{
    public interface IDataStorageManager
    {
        IDataStorage GetDataStorage(Guid quadId);
        bool CreateNewDataStorage(IDataStorage dataStorage);
    }
}
