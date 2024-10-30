using EmberToolkit.Common.Interfaces.Settings;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters
{
    public class FullscreenToggleAdapter  : EmberBehaviour
    {
        private ISettingsManager _settingsManager;

        [SerializeField] private Toggle fullscreenToggle;
        


        protected override void Awake()
        {
            base.Awake();
            RequestService(out _settingsManager);

            GetRequiredComponent(out fullscreenToggle);
            SubscribeEvent(_settingsManager, nameof(_settingsManager.OnRevertChanges), LoadSettingsFullscreenValue);


        }

        public void ToggleFullscreen()
        {
            if(fullscreenToggle != null) {
                _settingsManager.SetFullscreenMode(fullscreenToggle.isOn);
            }
        }

        public void LoadSettingsFullscreenValue()
        {
            bool fullscreenValue = _settingsManager.GetFullscreenMode();
            fullscreenToggle.isOn = fullscreenValue;
        }


    }
}
