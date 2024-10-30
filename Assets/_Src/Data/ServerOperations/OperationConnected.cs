using Sirenix.OdinInspector;
using SubNet.Common.Enum.Data.ServerOperations;
using System;

namespace SubNet.Data.ServerOperations
{
    public class OperationConnected : AServerOperationState
    {
        public override EServerOperationState State => EServerOperationState.Connected;
        [ShowInInspector, ReadOnly]
        protected override string _name => "Connected State";

        public override event Action OnStateEntered;
        public override event Action OnStateExited;

        /// <summary>
        /// High Level operations that need to occur during this state happen here.
        /// </summary>
        public override void ProcessGameStateChange()
        {
            OnStateEntered?.Invoke();
        }

        public override void TriggerStateEnd() => OnStateExited?.Invoke();
    }
}
