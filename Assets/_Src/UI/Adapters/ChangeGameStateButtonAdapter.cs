using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Game;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters
{
    public class ChangeGameStateButtonAdapter : EmberBehaviour
    {
        private IGameStateManager<SubnetGameStates> _stateManager;

        [SerializeField] private Button loadBtn;
        [SerializeField] private SubnetGameStates targetGameState = SubnetGameStates.NULL;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _stateManager);
            if (loadBtn != null || GetRequiredComponent(out loadBtn))
            {
                loadBtn.onClick.AddListener(ChangeGameState);
            }
        }

        public void ChangeGameState()
        {
            if (targetGameState != SubnetGameStates.NULL)
            {
                _stateManager.ChangeGameState(targetGameState);
            }
        }
    }
}
