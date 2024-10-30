using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Desktop.Servers
{
    public class LoginButtonAdaptor : EmberBehaviour
    {
        //Services
        private IServerOperationManager _serverOperationManager;
        //UI Elements
        [SerializeField] private Button _loginButton;
        [SerializeField] private TMP_InputField _passwordInput;
        //Locals


        protected override void Awake()
        {
            base.Awake();
            RequestService(out _serverOperationManager);
            if(IsLoginButtonSet())
            {
                _loginButton.onClick.AddListener(OnClick);
            }

        }

        private void OnClick()
        {
            //Add Validations?
            _serverOperationManager.LoginToServer(_passwordInput.text);
        }
        //Helpers
        private bool IsLoginButtonSet()
        {
            if (_loginButton == null)
            {
                _loginButton = GetComponent<Button>();
                if (_loginButton == null)
                {
                    Debug.LogError("LoginButtonAdaptor: LoginButton not set");
                }
            }
            return _loginButton != null;
        }
    }
}
