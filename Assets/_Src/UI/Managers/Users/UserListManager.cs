using EmberToolkit.Unity.Behaviours;
using Subnet.UI.Adapters.Menus.UserButtons;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Structs.Data.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Subnet.UI.Managers.Users
{
    public class UserListManager : EmberBehaviour
    {
        private ISaveGameManager _saveGameManager;
        [SerializeField] GameObject agentBtnPrefab;

        [SerializeField] TMP_InputField usernameInput;
        [SerializeField] TMP_InputField passwordInput;

        private List<GameObject> agentPrefabList = new List<GameObject>();
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _saveGameManager);
            SetUpUserList();
            if(_saveGameManager != null)
            {
                //TODO: Fix this after updating the OnMetaDataRefresh event in SaveGameManager
                //SubscribeEvent(_saveGameManager, nameof(_saveGameManager.OnMetaDataRefresh), SetUpUserList);
            }
        }

        public void SetUpUserList()
        {
            ClearAgentList();
            foreach(var agent in _saveGameManager.GetPlayerDataList())
            {
                var agentBtn = Instantiate(agentBtnPrefab, transform);
                var agentAdapter = agentBtn.GetComponent<UserListAgentAdapter>();
                agentAdapter.SetUpAgentBtnPrefab(agent, usernameInput, passwordInput);
                agentPrefabList.Add(agentBtn);
            }
        }

        private void ClearAgentList()
        {
            foreach(GameObject agent in agentPrefabList)
            {
                Destroy(agent);
            }
            agentPrefabList.Clear();
        }
    }
}
