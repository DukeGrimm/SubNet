using EmberToolkit.Common.Interfaces.Settings;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Settings;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Subnet.UI.Adapters
{
    public class ScreenResDropdownAdapter : EmberBehaviour
    {
        private ISettingsManager _settingsManager;
        private IGraphicsOptions _graphicsOpt;
        [SerializeField] private TMP_Dropdown screenResDropdown;

        private List<string> resOptionsCache = new List<string>();

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _settingsManager);
            GetRequiredComponent(out screenResDropdown);
            RequestService(out _graphicsOpt);

            resOptionsCache = _graphicsOpt.GetResolutionOptions();
            SetResOptions();
            SubscribeEvent(_settingsManager, nameof(_settingsManager.OnRevertChanges), LoadScreenResPrefsValue);


        }
        public void SetScreenResSetting()
        {
            if(screenResDropdown != null) {
                _settingsManager.SetResolution(screenResDropdown.value);
            }
        }

        private void SetResOptions()
        {
            screenResDropdown.ClearOptions();
            screenResDropdown.AddOptions(resOptionsCache);
        }

        private void LoadScreenResPrefsValue()
        {
            int screenResValue = _settingsManager.GetResolutionSetting();
            screenResDropdown.SetValueWithoutNotify(screenResValue);
        }
    }
}
