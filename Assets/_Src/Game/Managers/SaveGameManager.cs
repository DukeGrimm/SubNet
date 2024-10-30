using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game;
using SubNet.Common.Interfaces.Settings;
using SubNet.Common.Structs.Data.Player;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SubNet.Game.Managers
{
    public class SaveGameManager : EmberSingleton, ISaveGameManager
    {
        ISaveLoadController _saveLoadController;
        IGameDataManager _gameDataManager;
        ISubNetSettings _subNetSettings;

        PlayerDataMeta _playerDataMeta;
        List<PlayerDataMeta> _cachedPlayers;

        private FileSystemWatcher fileWatcher;
        private DateTime lastRead = DateTime.MinValue;

        public event Action OnMetaDataRefresh;
        protected override void Awake()
        {
            base.Awake();
            RequestService(out _subNetSettings);
            RequestService(out _saveLoadController);
            RequestService(out _gameDataManager);
            /* Having problems with the FileWatching triggering more than once per frame, causing issues I think with trying to clear the agent list and create a new one.
             * Not critical for Prototype, circle back later.
             */
            //StartFileWatching();
            _cachedPlayers = GetPlayerDataList();
        }

        protected override void OnDestroy()
        {
            //UnbindFileWatcherEvents();
            base.OnDestroy();
        }

        private void StartFileWatching()
        {
            // Initialize the FileSystemWatcher
            fileWatcher = new FileSystemWatcher
            {
                Path = _subNetSettings.SavePath,
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*" // Monitor changes to all files
            };

            // Add event handlers
            //SubscribeEvent<FileSystemEventHandler>(fileWatcher, nameof(fileWatcher.Changed), OnFilesChanged);
            //SubscribeEvent<FileSystemEventHandler>(fileWatcher, nameof(fileWatcher.Created), OnFilesChanged);
            //SubscribeEvent<FileSystemEventHandler>(fileWatcher, nameof(fileWatcher.Deleted), OnFilesChanged);
            //SubscribeEvent<FileSystemEventHandler>(fileWatcher, nameof(fileWatcher.Renamed), OnFilesChanged);
            BindFileWatcherEvents();
            // Begin watching
            fileWatcher.EnableRaisingEvents = true;
        }

        private void BindFileWatcherEvents()
        {
            fileWatcher.Changed += OnFilesChanged;
            fileWatcher.Created += OnFilesChanged;
            fileWatcher.Deleted += OnFilesChanged;
            fileWatcher.Renamed += OnFilesChanged;
        }
        private void UnbindFileWatcherEvents()
        {
            fileWatcher.Changed -= OnFilesChanged;
            fileWatcher.Created -= OnFilesChanged;
            fileWatcher.Deleted -= OnFilesChanged;
            fileWatcher.Renamed -= OnFilesChanged;
        }


        public void SaveGame()
        {
            if(!string.IsNullOrEmpty(_playerDataMeta.Username))
            {
                SaveMetaFile();
                _saveLoadController.Save(_playerDataMeta.Username + ".sav");
            }else
            {
                Debug.LogError("SaveGameManager- SaveGame - Username is empty");
            }

        }

        public void LoadGame(PlayerDataMeta playerDataMeta)
        {
            if (!string.IsNullOrEmpty(playerDataMeta.Username))
            {
                _saveLoadController.Load(playerDataMeta.Username + ".sav");
            }
        }
        private void SaveMetaFile() => _saveLoadController.SaveObject(_playerDataMeta, _playerDataMeta.Username + ".meta");

        public List<PlayerDataMeta> GetPlayerDataList()
        {
            if(_cachedPlayers != null && _cachedPlayers.Count > 0)
            {
                return _cachedPlayers;
            }
            //Get the list of objects loaded from the save file location
            List<PlayerDataMeta> data = _saveLoadController.LoadAllObjects<PlayerDataMeta>("meta");
            // Create a new list to store the PlayerDataMeta objects that have a corresponding .sav file
            List<PlayerDataMeta> validData = new List<PlayerDataMeta>();

            foreach (PlayerDataMeta playerDataMeta in data)
            {
                // Construct the path of the .sav file
                string saveFilePath = _subNetSettings.SavePath + "\\"+playerDataMeta.Username + ".sav";

                // Check if the .sav file exists
                if (File.Exists(saveFilePath))
                {
                    // If the .sav file exists, add the PlayerDataMeta object to the validData list
                    validData.Add(playerDataMeta);
                }
            }
            //Cannot invoke event here, as it will cause an infinite loop
            //TODO: Update event to pass the list of PlayerDataMeta Objects via the delegate
            //OnMetaDataRefresh?.Invoke();
            return validData;
        }
        
        public void CreateNewPlayerAndSave(string username, string password)
        {
            _gameDataManager.CreateNewPlayer(username, password);
            _playerDataMeta = _gameDataManager.GetPlayerDataMeta();
            //Save Meta FIle for userList
            SaveMetaFile();
            //Start process to Invoke saving on objects set to save, such as the PlayerData
            SaveGame();
        }



        private void OnFilesChanged(object sender, FileSystemEventArgs e)
        {
            var lastWriteTime = File.GetLastWriteTime(e.FullPath);
            var timeDifference = (DateTime.Now - lastRead).TotalSeconds;

            if (timeDifference > 1)
            {
                OnMetaDataRefresh?.Invoke();
                lastRead = DateTime.Now;
            }
        }

        public bool MainMenuLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Debug.LogError("SaveGameManager: Username or password is empty");
                return false;
            }

            if(_cachedPlayers.Any(x => x.Username == username && x.Password == password))
            {
                PlayerDataMeta playerDataMeta = _cachedPlayers.First(x => x.Username == username);
                LoadGame(playerDataMeta);
                return true;
            }
            else
            {
                Debug.LogError("SaveGameManager: Username not found");
                return false;
            }
        }
    }
}
