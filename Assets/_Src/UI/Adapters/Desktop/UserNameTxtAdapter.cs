using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Subnet.UI.Adapters.Desktop
{
    public class UserNameTxtAdapter : EmberBehaviour
    {
        private IGameDataManager _gameDataManager;

        [SerializeField] private TMP_Text userNameTxt;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _gameDataManager);
            if (userNameTxt != null || GetRequiredComponent(out userNameTxt))
            {
                userNameTxt.text = _gameDataManager.GetUserName();
            }
        }

    }
}
