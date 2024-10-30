using Sirenix.OdinInspector;
using SubNet.Common.Enum.Game;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace SubNet.Data.GameStates
{
    public class AppStartState : SubnetGameState
    {

        public override SubnetGameStates State => SubnetGameStates.AppStart;
        [ShowInInspector, ReadOnly]
        protected override string _name => "App Start";

        public override event Action OnStateEntered;
        public override event Action OnStateExited;

        public override void ProcessGameStateChange()
        {
            #if UNITY_EDITOR
            Debug.Log("Processing " + GetType().Name +" State...");
            #endif
            OnStateEntered?.Invoke();
        }

        public override void TriggerStateEnd() => OnStateExited?.Invoke();


    }
}
