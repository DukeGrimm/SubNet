using SubNet.Common.Interfaces.Player;
using SubNet.Common.Structs.Data.Player;
using System;

namespace SubNet.Common.Interfaces.Game
{
    public interface IGameDataManager
    {

        IPlayerData GetPlayerData();
        //void LoadPlayerData(IPlayerData loadPlayerData);
        PlayerDataMeta GetPlayerDataMeta();
        void CreateNewPlayer(string username, string password);
        void AddPlayTime(TimeSpan time);
        string GetUserName();

    }
}
