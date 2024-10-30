using EmberToolkit.Common.Attributes;
using EmberToolkit.Unity.Behaviours;
using Sirenix.Serialization;
using SubNet.Common.Interfaces.Game.Player;
using SubNet.Common.Structs.Data.Player;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Game.Managers.Player
{

    /// <summary>
    /// Manage Wallet Entries for the player.
    /// Currently will store WalletEntry as bank accounts. In future will only be cached balances from bank accounts tracked in bank servers.
    /// </summary>
    public class WalletManager : EmberSingleton, IWalletManager
    {
        /// <summary>
        /// Default bank account for the player, the account number can be unique, but GUID needs to be the same across accoutns for purposes of loading.
        /// </summary>
        private static Guid DefaultPlayerBankAccountId = new Guid("84e5159f-6d66-43f5-86f7-81e66765c5c2");

        [OdinSerialize, SaveField]
        private Dictionary<Guid, WalletEntry> walletEntries = new Dictionary<Guid, WalletEntry>();
        //The account set up as the default account for withdrawing and depositing
        private Guid primaryAccountId = Guid.Empty;

        protected override void Awake()
        {
            base.Awake();
            //Load wallet entries from save data
        }

        private void CreateDefaultAccount()
        {
            WalletEntry defaultAccount = new WalletEntry(DefaultPlayerBankAccountId, "Default Account", Guid.Empty, DateTime.Now, 0);
            walletEntries.Add(DefaultPlayerBankAccountId, defaultAccount);
        }
        public float GetPrimaryBalance()
        {
            if (primaryAccountId == Guid.Empty || !AccountExists(primaryAccountId))
            {
                return -1f;
            }
            return walletEntries[primaryAccountId].Balance;
        }
        public void DepositFunds(float amount)
        {
            if (!TransactionValid(amount) || !AccountExists(primaryAccountId))
            {
                return;
            }
            WalletEntry primary = walletEntries[primaryAccountId];
            primary.Balance += amount;
            walletEntries[primaryAccountId] = primary;
        }
        public void WithdrawFunds(float amount)
        {
            if (!TransactionValid(amount) || !AccountExists(primaryAccountId))
            {
                return;
            }
            WalletEntry primary = walletEntries[primaryAccountId];
            primary.Balance -= amount;
            walletEntries[primaryAccountId] = primary;
        }

        #region Helpers
        private bool AccountExists(Guid accountId)
        {
            if (!walletEntries.ContainsKey(primaryAccountId))
            {
                Debug.LogError("Primary Account not found in Wallet Entries");
                return false;
            }
            return true;
        }
        private bool TransactionValid(float amount)
        {
            if (amount < 0)
            {
                Debug.LogError("Amounts need to be positive values. If you need to remove funds, use the withdraw method.");
                return false;
            }
            return true;
        }
        #endregion

    }
}
