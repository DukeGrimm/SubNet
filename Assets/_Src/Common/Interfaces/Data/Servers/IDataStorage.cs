using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Structs.Data.Servers;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Data.Servers
{
    public interface IDataStorage : IEmberObject
    {
        int FreeQuads { get; }                      
        int MaxQuads { get; }
        int UsedQuads { get; }
        bool UploadData(QuadObject quadObject);
        QuadObject DownloadData(Guid quadId);

        IEnumerable<QuadObject> GetAllDataInStorage();

        void AddQuads(int quads);
        bool DeleteQuad(Guid quadId);

        QuadObject GetRandomQuad();
        QuadObject GetRandomQuadWhere(Func<QuadObject, bool> filter);

        void CreateRandomQuads(int count, string prefix);

    }
}
