using SubNet.Common.Enum.Data.ServerOperations;
using System;

namespace SubNet.Data.ServerOperations
{
    public class OperationDisconnected : AServerOperationState
    {
        public override EServerOperationState State => EServerOperationState.Disconnected;
        protected override string _name => "Disconnected State";
        public override event Action OnStateEntered;
        public override event Action OnStateExited;
        public override void ProcessGameStateChange()
        {
            OnStateEntered?.Invoke();
        }
        public override void TriggerStateEnd() => OnStateExited?.Invoke();
    }
}
