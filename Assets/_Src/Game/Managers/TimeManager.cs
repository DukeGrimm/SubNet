using EmberToolkit.Common.Attributes;
using EmberToolkit.Common.DataTypes;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Controllers;
using EmberToolkit.Common.Interfaces.Unity.Behaviours.Managers.Time;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Game.Managers
{
    public class TimeManager : EmberSingleton, ITimeManager, ITimeManagerEvents
    {
        [SaveField]
        private DateTime _gameTime;
        [SaveField]
        private DateTime _previousDate;
        [ShowInInspector, ReadOnly]
        private string CurrentTime => _gameTime.ToString();

        [SerializeField]
        private UDateTime GameStartTime = new UDateTime(2044, 2, 6, 0, 0);

        [SerializeField]
        private int timeFactor = 1;

        [SerializeField]
        [SaveField]
        private bool isPaused;

        public bool IsPaused => isPaused;

        public DateTime InGameTime => _gameTime;


        public event Action<DateTime> OnTimeUpdated;
        public event Action<DateTime> OnDateUpdated;

        protected override void Awake()
        {
            _gameTime = GameStartTime.DateTime;
            //SaveObject = true;
            base.Awake();
        }

        public void Update()
        {
            if (!IsPaused) { UpdateTime(); }
        }
        private void UpdateTime()
        {
            // Calculate the delta time based on the custom factor.
            float deltaTime = Time.deltaTime * timeFactor;
            // Convert delta time to TimeSpan (assuming seconds).
            TimeSpan deltaSpan = TimeSpan.FromSeconds(deltaTime);


            // Update the in-game time with the adjusted delta time.
            _gameTime = _gameTime.Add(deltaSpan);

            OnTimeUpdated?.Invoke(_gameTime);//ToString("HH:mm"));
            if (_previousDate != _gameTime.Date)
            {
                _previousDate = _gameTime.Date;
                OnDateUpdated?.Invoke(_gameTime.Date);
            }

            // Perform other time-related tasks or update game systems.
        }

        public void LoadGameTime(DateTime gameTime) => _gameTime = gameTime;

        #region Actions
        public void SetPauseState(bool pauseState) => isPaused = pauseState;
        public void TogglePause() => isPaused = !isPaused;
        public void PushTimeForward(int minutes, int hours = 0)
        {
            _gameTime.AddHours(hours);
            _gameTime.AddMinutes(minutes);
        }

        public void SetTimeFactor(int factor) => timeFactor = factor;
        #endregion


    }
}
