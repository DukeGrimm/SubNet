using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using SubNet.Common.Enum.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Game.SceneConductors
{
    public class DesktopConductor : SceneConductor
    {

        //States for handling scene Changes
        private IGameState<SubnetGameStates> mainMenuState;
        //States for handling Desktop Gameplay changes
        //private IGameState<SubnetGameStates> pauseState;

        protected override void Awake()
        {
            base.Awake();
            if (_stateManager.FindGameState(out mainMenuState, SubnetGameStates.MainMenu))
            {
                SubscribeEvent(mainMenuState, GameStateEvents.OnStateEntered.ToString(), LoadMainMenu);
            }
        }

        //This method is called switches the scene to the Main menu, when the main menu state is entered.

        private void LoadMainMenu() => LoadScene(SubnetGameStates.MainMenu);





    }
}
