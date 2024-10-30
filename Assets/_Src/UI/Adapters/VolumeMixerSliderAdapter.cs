using EmberToolkit.Common.Interfaces.Settings;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Enum.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters
{
    public class VolumeMixerSliderAdapter : EmberBehaviour
    {
        private ISettingsManager _settingsManager;

        [SerializeField] private SubnetAudioMixers mixer;
        [SerializeField] private Slider audioSlider;

        private string mixerName => mixer.ToString();


        protected override void Awake()
        {
            base.Awake();
            RequestService(out _settingsManager);
            GetRequiredComponent(out audioSlider);
            LoadSettingsMixerValue();
            SubscribeEvent(_settingsManager, nameof(_settingsManager.OnRevertChanges), LoadSettingsMixerValue);
        }

        public void SetVolume()
        {
            float newMixerValue = audioSlider.value;
            _settingsManager.SetMixerSetting(mixerName, newMixerValue);
        }

        public void LoadSettingsMixerValue()
        {
            float mixerValue = _settingsManager.GetMixerSetting(mixerName);
            audioSlider.value = mixerValue;
        }


    }
}
