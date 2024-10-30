using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Data;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Data.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Structs.Data.Servers
{
    public struct QuadObject : IQuadObject
    {
        [ShowInInspector]
        private Guid id;
        [ShowInInspector]
        private string name;
        [ShowInInspector]
        private int size;
        public Guid Id => id;
        public string Name => name;
        public int Size => size;

        public Type ItemType => GetType();

        [JsonConstructor]
        public QuadObject([JsonProperty("Id")] string id, [JsonProperty("Name")] string name, [JsonProperty("Size")] int size)
        {
            this.id = Guid.Parse(id);
            this.name = name;
            this.size = size;
        }
    }
}
