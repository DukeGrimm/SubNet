using SubNet.Common.Structs.Data.Player;
using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Game
{
    public interface ISaveGameManager
    {
        event Action OnMetaDataRefresh;
        void SaveGame();
        void LoadGame(PlayerDataMeta playerDataMeta);
        List<PlayerDataMeta> GetPlayerDataList();
        void CreateNewPlayerAndSave(string username, string password);

        bool MainMenuLogin(string username, string password);

    }
}
