using EmberToolkit.Common.DataTypes;
using EmberToolkit.Common.Interfaces.Repository;
using Newtonsoft.Json;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Common.Structs.Data.Player
{
    /// <summary>
    /// Will represent bank accounts registered to the player, for the purpose of tracking their balance and transactions
    /// As well as containing IDs needed to perform transactions between bank servers
    /// </summary>
    public struct WalletEntry : IEmberObject
    {
        [OdinSerialize]
        private Guid id;
        public Guid Id => id;
        public Type ItemType => GetType();
        [OdinSerialize]
        public string Name { get; set; }
        [OdinSerialize]

        private Guid bankServerId;
        public Guid BankServerId => bankServerId;
        [OdinSerialize]
        public UDateTime LastUpdated { get; set; }
        [OdinSerialize]
        public float Balance { get; set; }

        [JsonConstructor]
        public WalletEntry([JsonProperty("Id")] string id, [JsonProperty("Name")] string name, [JsonProperty("BankServerId")] string bankServerId, [JsonProperty("Balance")] string balance)
        {
            this.id = Guid.Parse(id);
            Name = name;
            this.bankServerId = Guid.Parse(bankServerId);
            LastUpdated = new UDateTime();
            Balance = float.Parse(balance);
        }

        public WalletEntry(Guid id, string name, Guid bankServerId, DateTime lastUpdated, float balance)
        {
            this.id = id;
            Name = name;
            this.bankServerId = bankServerId;
            LastUpdated = new UDateTime(lastUpdated);
            Balance = balance;
        }


        public WalletEntry(string id, string name, string bankServerId, DateTime lastUpdated, string balance)
        {
            this.id = new Guid(id);
            Name = name;
            this.bankServerId = new Guid(bankServerId);
            LastUpdated = new UDateTime(lastUpdated);
            Balance = float.Parse(balance);
        }


        public WalletEntry(string name, Guid bankServerId, DateTime lastUpdated, float balance)
        {
            id = Guid.NewGuid();
            Name = name;
            this.bankServerId = bankServerId;
            LastUpdated = new UDateTime(lastUpdated);
            Balance = balance;
        }
    }
}
