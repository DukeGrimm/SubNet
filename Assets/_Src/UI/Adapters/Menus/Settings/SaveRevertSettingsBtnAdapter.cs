using EmberToolkit.Common.Interfaces.Settings;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Menus.Settings
{
    public class SaveRevertSettingsBtnAdapter : EmberBehaviour
    {
        private ISettingsManager _settingsManager;

        [SerializeField] private Button saveSettingsBtn;
        [SerializeField] private bool RevertChangesInstead = false;
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _settingsManager);
            if (saveSettingsBtn != null || GetRequiredComponent(out saveSettingsBtn))
            {
                if(RevertChangesInstead)
                    saveSettingsBtn.onClick.AddListener(RevertSettings);
                else
                    saveSettingsBtn.onClick.AddListener(SaveSettings);
            }
        }

        public void SaveSettings() => _settingsManager.SaveChanges();

        public void RevertSettings() => _settingsManager.RevertChanges();
    }
}
