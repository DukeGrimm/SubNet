using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using GuildLegends.Game.GameStates;
using SubNet.Common.Enum.Data.ServerOperations;
using SubNet.Common.Interfaces.Game.ServerOperations;
using SubNet.Data.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SubNet.Game.Controllers.Content
{
    public class ServerOperationController : GameStateManager<EServerOperationState>, IServerOperationController
    {
        private IEnumerable<Type>? operationStateCache;
        protected override void Awake()
        {
            base.Awake();
            ChangeGameState(EServerOperationState.Disconnected);
        }
        protected override IEnumerable<Type>? GetGameStateTypes()
        {
            if(operationStateCache == null)
            {
                operationStateCache = Assembly.GetAssembly(typeof(AServerOperationState)).GetTypes().Where(y => typeof(AServerOperationState).IsAssignableFrom(y) && y.IsAbstract == false);
            }
            //Use the assembly where the GameStates live 
            return operationStateCache;
        }
    }
}
