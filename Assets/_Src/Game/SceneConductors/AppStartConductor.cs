using EmberToolkit.Common.Enum.Game;
using EmberToolkit.Common.Interfaces.Game;
using SubNet.Common.Enum.Game;

namespace SubNet.Game.SceneConductors
{
    public class AppStartConductor : SceneConductor
    {
        private IGameState<SubnetGameStates> mainMenuState;

        protected override void Awake()
        {
            base.Awake();
            if (_stateManager.FindGameState(out mainMenuState, SubnetGameStates.MainMenu))
            {
                SubscribeEvent(mainMenuState, GameStateEvents.OnStateEntered.ToString(), LoadMainMenu);
            }
        }

        private void LoadMainMenu() => LoadScene(SubnetGameStates.MainMenu);
    }
}
