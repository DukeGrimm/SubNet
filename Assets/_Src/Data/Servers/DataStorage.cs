using EmberToolkit.Unity.Data;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using SubNet.Common.Interfaces.Data.Servers;
using SubNet.Common.Structs.Data.Servers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.Servers
{
    [System.Serializable]
    public class DataStorage : EmberObject, IDataStorage
    {
        [OdinSerialize, JsonProperty]
        private Dictionary<Guid, QuadObject> dataStorageDict = new Dictionary<Guid, QuadObject>();
        [ShowInInspector]
        private int maxQuads = 1000;
        [ShowInInspector]
        private int usedQuads = 0;
        [ShowInInspector, JsonProperty]
        private int testNonInterfaceVar = 3;
        [JsonIgnore]
        public int FreeQuads => MaxQuads - UsedQuads;
        public int MaxQuads => maxQuads;
        public int UsedQuads => usedQuads;

        public override Type ItemType => GetType();

        // Parameterless constructor for deserialization
        public DataStorage() { }

        [JsonConstructor]
        public DataStorage([JsonProperty("Id")] string id, [JsonProperty("Name")] string name, [JsonProperty("MaxQuads")] int maxQuads, [JsonProperty("UsedQuads")] int usedQuads, Dictionary<Guid, QuadObject> dataStorageDict, int testNonInterfaceVar) : base(Guid.Parse(id), name)
        {
            this.maxQuads = maxQuads;
            this.usedQuads = usedQuads;
            this.dataStorageDict = dataStorageDict;
            this.testNonInterfaceVar = testNonInterfaceVar;
        }
        public DataStorage(Guid id, int maxQuads = 100) : base(id, "DataStorage")
        {
            this.maxQuads = maxQuads;
        }
        public DataStorage(int maxQuads)
        {
            this.maxQuads = maxQuads;
        }

        public QuadObject DownloadData(Guid quadId) => dataStorageDict[quadId];

        public IEnumerable<QuadObject> GetAllDataInStorage() => dataStorageDict.Values;

        public bool UploadData(QuadObject quadObject)
        {
            if(SpaceAvailable(quadObject.Size))
            {
                dataStorageDict.Add(quadObject.Id, quadObject);
                usedQuads += quadObject.Size;
                return true;
            }
            return false;
        }
        public bool DeleteQuad(Guid quadId)
        {
            if(dataStorageDict.ContainsKey(quadId))
            {
                usedQuads -= dataStorageDict[quadId].Size;
                dataStorageDict.Remove(quadId);
                return true;
            }
            return false;
        }

        public void AddQuads(int quads)
        {
            maxQuads += quads;
        }

        public void CreateRandomQuads(int count, string serverPrefix = "")
        {
            for (int i = 0; i < count; i++)
            {
                QuadObject quad = new QuadObject(Guid.NewGuid().ToString(), serverPrefix + "Quad" + i, 1);
                UploadData(quad);
            }
        }
        public QuadObject GetRandomQuad() => dataStorageDict.Values.ElementAt(UnityEngine.Random.Range(0, dataStorageDict.Count));
        public QuadObject GetRandomQuadWhere(Func<QuadObject, bool> filter) => dataStorageDict.Values.Where(filter).ElementAt(UnityEngine.Random.Range(0, dataStorageDict.Count));

        #region Helpers
        private bool SpaceAvailable(int size) => FreeQuads >= size;
        #endregion
    }
}
