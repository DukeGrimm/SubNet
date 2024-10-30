#nullable enable
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using GuildLegends.Game.GameStates;
using Sirenix.OdinInspector;
using SubNet.Common.Enum.Game;
using SubNet.Data.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SubNet.Game
{
    public class SubnetGameStateManager : GameStateManager<SubnetGameStates>, IGameStateManager<SubnetGameStates>
    {
        private IEnumerable<Type>? GameStateCache;
        protected override void Awake()
        {
            base.Awake();
            ChangeGameState(SubnetGameStates.AppStart);
        }

        protected override IEnumerable<Type>? GetGameStateTypes()
        {
            if(GameStateCache == null)
            {
                GameStateCache = Assembly.GetAssembly(typeof(SubnetGameState)).GetTypes().Where(y => typeof(SubnetGameState).IsAssignableFrom(y) && y.IsAbstract == false);
            }
            //Use the assembly where the GameStates live 
            return GameStateCache;
        }


    }
}
