using Sirenix.OdinInspector;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Input;
using SubNet.Input;
using System;
using UnityEngine;

namespace SubNet.Data.GameStates
{
    public class DesktopState : SubnetGameState
    {
        public override SubnetGameStates State => SubnetGameStates.Desktop;

        [ShowInInspector, ReadOnly]
        protected override string _name => "DesktopState";

        public override event Action OnStateEntered;
        public override event Action OnStateExited;

        private MasterInputActions _inputActions;

        public DesktopState() : base()
        {
            _inputActions = GetService<IMasterInputActions>() as MasterInputActions;

            OnStateEntered += EnableMainActionMap;
            OnStateExited += DisableMainActionMap;
        }

        public override void ProcessGameStateChange()
        {
#if UNITY_EDITOR
            Debug.Log("Processing " + GetType().Name + " State...");
#endif
            OnStateEntered?.Invoke();
        }

        public override void TriggerStateEnd() => OnStateExited?.Invoke();

        private void EnableMainActionMap() => _inputActions.UI.Enable();
        private void DisableMainActionMap() => _inputActions.UI.Disable();

    }
}
