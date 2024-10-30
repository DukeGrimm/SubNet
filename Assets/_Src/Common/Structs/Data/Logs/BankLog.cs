using EmberToolkit.Common.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Structs.Data.Logs
{
    public struct BankLog : IEmberObject
    {
        private Guid id;
        public Guid Id => id;
        public Type ItemType => GetType();
        public string Name => "Bank Log: " + id.ToString();

        private Guid localbankServerId;
        public Guid LocalBankServerId => localbankServerId;
        private Guid remoteBankServerId;
        public Guid RemoteBankServerId => remoteBankServerId;

        public DateTime TransactionDate { get; set; }
        public float Balance { get; set; }
    }
}
