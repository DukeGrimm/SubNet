using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Input;
using SubNet.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Desktop.Pause
{
    /// <summary>
    /// Binds the PausePanel to the esc key
    /// TODO: Consider moving to a game state or scene conductor
    /// </summary>
    public class PausePanelAdapter : EmberBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private Button returnButton;

        private MasterInputActions _inputActions;
        protected override void Awake()
        {
            base.Awake();
            _inputActions = GetService<IMasterInputActions>() as MasterInputActions;

            SubscribeEvent<InputAction.CallbackContext>(_inputActions.UI.Cancel, "performed", TogglePausePanel);
            if(returnButton != null)
            {
                returnButton.onClick.AddListener(TogglePausePanel);
            }
        }

        private void TogglePausePanel(InputAction.CallbackContext context)
        {
            TogglePausePanel();
        }

        private void TogglePausePanel()
        {
            // Check if any UI element is currently selected
            if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject != returnButton.gameObject)
            {
                // Optionally, you can do something specific if a UI element is selected
                // For example, you might want to deselect it:
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                // If no UI element is selected, toggle the pause panel
                pausePanel.SetActive(!pausePanel.activeSelf);
            }
        }
    }
}
