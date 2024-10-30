using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Structs.Data.Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Menus.UserButtons
{
    public class UserListAgentAdapter : EmberBehaviour
    {
        [SerializeField] private Button userBtn;
        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private TMP_InputField passwordInput;

        [SerializeField] private TMP_Text agentNameTxt;
        [SerializeField] private TMP_Text agentPlayTimeTxt;

        private PlayerDataMeta agentMeta;

        protected override void Awake()
        {
            base.Awake();
            if (userBtn != null || GetRequiredComponent(out userBtn))
            {
                userBtn.onClick.AddListener(AutoFillAgentInfo);
            }

        }

        public void SetUpAgentBtnPrefab(PlayerDataMeta metaData, TMP_InputField inputUser, TMP_InputField inputPass)
        {
            agentMeta = metaData;
            usernameInput = inputUser;
            passwordInput = inputPass;
            if(agentNameTxt != null)
            {
                agentNameTxt.text = agentMeta.Username;
            }
            if(agentPlayTimeTxt != null)
            {
                agentPlayTimeTxt.text = agentMeta.PlayTime.ToString();
            }
        }

        public void AutoFillAgentInfo()
        {
            if (agentMeta.IsValid)
            {
                usernameInput.text = agentMeta.Username;
                passwordInput.text = agentMeta.Password;
            }
        }
    }
}
