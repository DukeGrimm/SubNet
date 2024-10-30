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
    public class CreateNewUserAdapter : EmberBehaviour
    {
        private ISaveGameManager _saveGameManager;
        private IGameStateManager<SubnetGameStates> _stateManager;

        [SerializeField] private Button saveGameConfirmBtn;
        [SerializeField] private TMP_InputField usernameInput;
        [SerializeField] private TMP_InputField passwordInput;
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _saveGameManager);
            RequestService(out _stateManager);

            if(usernameInput != null&&passwordInput != null)
            {
                saveGameConfirmBtn.onClick.AddListener(CreateNewUser);

            }
        }

        public void CreateNewUser()
        {
            string username = usernameInput.text;
            string password = passwordInput.text;
            //TODO: Add additional Username and Password Validation
            if(!UserNameValidate(username))
            {
                Debug.LogError("CreateNewUserAdapter - CreateNewUser - Username is empty");
                return;
            }
            else if(!PasswordValidate(password))
            {
                Debug.LogError("CreateNewUserAdapter - CreateNewUser - Password is empty");
                return;
            }
           else {
                _saveGameManager.CreateNewPlayerAndSave(username, password);
                _stateManager.ChangeGameState(SubnetGameStates.Desktop);

            }


        }
        private bool UserNameValidate(string username)
        {
            return !string.IsNullOrEmpty(username);
        }
        private bool PasswordValidate(string password)
        {
            return !string.IsNullOrEmpty(password);
        }
    }
}
