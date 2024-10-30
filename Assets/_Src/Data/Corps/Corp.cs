using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Data;
using SubNet.Common;
using SubNet.Common.Enum.Data.Corps;
using SubNet.Common.Interfaces.Corps;
using SubNet.Common.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.Corps
{
    /// <summary>
    /// Class for containing information about Corporations and groups in the Subnet network.
    /// </summary>
    public class Corp : EmberObject, ICorp
    {
        private ECorpClass corpClass;

        public ECorpClass Class => corpClass;

        public override Type ItemType => GetType();

        public Corp(string sName, ECorpClass newCorpClass) : base(sName)
        {
            corpClass = newCorpClass;
        }
        public Corp(ICorp corp) : base(corp.Id, corp.Name)
        {
            corpClass = corp.Class;
        }

        public Corp(CorpSO corpSO) : base(corpSO.Id, corpSO.Name)
        {
            corpClass = corpSO.Class;
        }
    }
}
