using EmberToolkit.Unity.GameStates;
using Sirenix.OdinInspector;
using SubNet.Common.Enum.Game;
using SubNet.Common.Interfaces.Input;
using SubNet.Input;
using System;
using UnityEngine;

namespace SubNet.Data.GameStates
{
    public class MainMenuState : SubnetGameState
    {
        public override SubnetGameStates State => SubnetGameStates.MainMenu;
        [ShowInInspector, ReadOnly]
        protected override string _name => "Main Menu State";

        public override event Action OnStateEntered;
        public override event Action OnStateExited;

        private MasterInputActions _inputActions;

        public MainMenuState() : base()
        {
            //Hack to allow locating by interface but holding it as the original implementation.
            //This is only due to the fact that MasterInputActions is a generated type.
            _inputActions = GetService<IMasterInputActions>()  as MasterInputActions;
            OnStateEntered += EnableMainActionMap;
            //OnStateExited += DisableMainActionMap;
        }

        public override void ProcessGameStateChange()
        {
#if UNITY_EDITOR
            Debug.Log("Processing " + nameof(this.GetType) + " State...");
#endif
            OnStateEntered?.Invoke();
        }

        public override void TriggerStateEnd()
        {
            //
        }

        private void EnableMainActionMap() => _inputActions.UI.Enable();
        private void DisableMainActionMap() => _inputActions.UI.Disable();
    }
}
