using EmberToolkit.Common.Attributes;
using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.Unity.Behaviours;
using Sirenix.OdinInspector;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Player;
using SubNet.Common.Structs.Data.Player;
using SubNet.Data.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubNet.Game.Managers
{
    /// <summary>
    /// Provides an access point for other scripts to access the player data.
    /// Provides PlayerDataMeta based on loaded PlayerData.
    /// </summary>
    public class GameDataManager : EmberSingleton, IGameDataManager
    {
        //SaveableObjects should always have a static GUID so that they load correctly during Loaded Games.
        private static Guid playerDataId = new Guid("{8C8F25B9-F592-4B3D-88F4-4A990CF6950F}");

        private ISaveLoadEvents _saveLoadEvents;
        private ISaveableObjectRepository _saveableRepo;
        [ShowInInspector, ReadOnly]
        private PlayerData playerData;

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _saveLoadEvents);
            RequestService(out _saveableRepo);
            //The player data needs to be constructed here so that it can be loaded from the save file.
            CreateNewPlayer("Default", "Default");
        }

        public IPlayerData GetPlayerData() => playerData;

        //public void LoadPlayerData(IPlayerData loadPlayerData)
        //{
        //    playerData = loadPlayerData as PlayerData;
        //}

        public PlayerDataMeta GetPlayerDataMeta() => playerData.GetMeta();

        public void CreateNewPlayer(string username, string password)
        {
            playerData = new PlayerData(playerDataId, username, password, _saveLoadEvents, _saveableRepo);
        }

        public void AddPlayTime(TimeSpan time)
        {
            playerData.AddPlayTime(time);
        }

        public string GetUserName() => playerData?.Username;

    }
}
