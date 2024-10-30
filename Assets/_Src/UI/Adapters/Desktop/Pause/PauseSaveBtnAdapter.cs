using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Desktop.Pause
{
    public class PauseSaveBtnAdapter : EmberBehaviour
    {
        private ISaveGameManager _saveGameManager;

        [SerializeField] private Button saveGameBtn;
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _saveGameManager);
            if(saveGameBtn != null|| GetRequiredComponent(out saveGameBtn))
            {
                saveGameBtn.onClick.AddListener(SaveGameOnClick);
            }
        }

        private void SaveGameOnClick()
        {
           _saveGameManager.SaveGame();
        }
    }
}
