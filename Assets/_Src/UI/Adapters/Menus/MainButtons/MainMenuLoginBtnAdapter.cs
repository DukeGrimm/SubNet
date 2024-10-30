using EmberToolkit.Common.Interfaces.Game;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Game;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI
{
    public class MainMenuLoginBtnAdapter : EmberBehaviour
    {
        
        private ISaveGameManager _saveGameManager;
        private IGameStateManager<SubnetGameStates> _stateManager;

        [SerializeField] private Button loginButton;

        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private TMP_InputField passwordInput;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _saveGameManager);
            RequestService(out _stateManager);
            loginButton.onClick.AddListener(OnLoginButtonClicked);
        }

        private void OnLoginButtonClicked()
        {
            if (string.IsNullOrEmpty(usernameInput.text) || string.IsNullOrEmpty(passwordInput.text))
            {
                Debug.LogError("Username or password is empty");
                return;
            }

            bool response = _saveGameManager.MainMenuLogin(usernameInput.text, passwordInput.text);
            if (response)
            {
                _stateManager.ChangeGameState(SubnetGameStates.Desktop);
            }
        }


    }
}
