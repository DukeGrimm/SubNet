using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using SubNet.Common.Enum.Data.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game.ServerOperations
{
    public interface IServerOperationController : IGameStateManager<EServerOperationState>
    {
    }
}
