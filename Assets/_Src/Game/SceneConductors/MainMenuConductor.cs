using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using SubNet.Common.Enum.Game;
using SubNet.Game.SceneConductors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SubNet.Game.SceneConductors
{
    public class MainMenuConductor : SceneConductor
    {
        private IGameState<SubnetGameStates> desktopGameState;
        
        //[SerializeField] private Selectable UI_SelectedOnSceneLoad;
        protected override void Awake()
        {
            base.Awake();
            if (_stateManager.FindGameState(out desktopGameState, SubnetGameStates.Desktop))
            {
                SubscribeEvent(desktopGameState, GameStateEvents.OnStateEntered.ToString(), LoadDesktopScene);
            }
            if (UI_SelectedOnSceneLoad != null) UI_SelectedOnSceneLoad.Select();
        }

        private void LoadDesktopScene()
        {
            LoadScene(SubnetGameStates.Desktop);
        }
    }
}
