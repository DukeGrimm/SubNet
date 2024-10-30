using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SubNet.Game.SceneConductors
{
    public abstract class SceneConductor : EmberSingleton
    {
        protected IGameStateManager<SubnetGameStates> _stateManager;
        //protected ISceneMaster _sceneMaster;

        [SerializeField] protected Selectable UI_SelectedOnSceneLoad;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _stateManager);
        }

        protected void LoadScene(SubnetGameStates gameScene)
        {
            SceneManager.LoadScene(gameScene.ToString(), LoadSceneMode.Single);
        }


    }
}
