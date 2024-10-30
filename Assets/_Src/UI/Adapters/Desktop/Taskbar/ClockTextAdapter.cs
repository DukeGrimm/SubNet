using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Time;
using EmberToolkit.Unity.Behaviours;
using System;
using TMPro;
using UnityEngine;

namespace Subnet.UI
{
    public class ClockTextAdapter : EmberBehaviour
    {
        private ITimeManagerEvents _timeEvents;

        [SerializeField] TMP_Text clockText;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _timeEvents);
            if(clockText != null)
            {
                SubscribeEvent<DateTime>(_timeEvents, nameof(_timeEvents.OnTimeUpdated), SetTimeText);
            }

        }

        public void SetTimeText(DateTime time)
        {
            clockText.text = time.ToString("MMM dd HH’:’mm’:’ss yyyy");
        }
    }
}
