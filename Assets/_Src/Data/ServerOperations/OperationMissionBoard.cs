using SubNet.Common.Enum.Data.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Data.ServerOperations
{
    public class OperationMissionBoard : AServerOperationState
    {
        public override EServerOperationState State => EServerOperationState.Missions;

        protected override string _name => "Mission State";

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
