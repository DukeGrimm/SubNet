using SubNet.Common.Enum.Data.ServerOperations;
using System;

namespace SubNet.Data.ServerOperations
{
    public class OperationDashboard : AServerOperationState
    {
        public override EServerOperationState State => EServerOperationState.Dashboard;
        protected override string _name => "Logged In State";

        public override event Action OnStateEntered;
        public override event Action OnStateExited;

        public override void ProcessGameStateChange()
        {
            OnStateEntered?.Invoke();
        }

        public override void TriggerStateEnd() => OnStateExited?.Invoke();
    }
}
