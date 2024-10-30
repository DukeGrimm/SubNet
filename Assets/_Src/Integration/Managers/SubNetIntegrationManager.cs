using EmberToolkit.Unity.Behaviours;
using EmberToolkit.Unity.Behaviours.Managers;
using EmberToolkit.Unity.Services;
using SubNet.Common.Interfaces.Settings;
using SubNet.Integration.Settings;
using SubNet.Input;
using System;
using UnityEngine;

namespace SubNet.Integration.Managers
{
    public class SubNetIntegrationManager : IntegrationManager
    {
        private ISubNetSettings _subSettings;

        private MasterInputActions _inputActions;
        protected override void Awake()
        {

            base.Awake();
            _inputActions = new MasterInputActions();
            _inputActions.Enable();


            ServiceConductor.Register(_inputActions, typeof(MasterInputActions));
        }

        protected override void InitializeSettings()
        {
          _subSettings = new SubNetSettings();
           ServiceConductor.Register(_subSettings, typeof(SubNetSettings));
        }
    }
}
