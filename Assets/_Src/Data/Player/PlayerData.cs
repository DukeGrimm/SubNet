using EmberToolkit.Common.Interfaces.Data;
using EmberToolkit.Common.Interfaces.Repository;
using EmberToolkit.DataManagement.Data;
using SubNet.Common.Interfaces.Player;
using SubNet.Common.Structs.Data.Player;
using System;

namespace SubNet.Data.Player
{
    [System.Serializable]
    public class PlayerData : SaveableObject, IPlayerData
    {
        //private Values
        private string username;
        private string password;
        private TimeSpan playTime;

        public PlayerData(Guid objId, string username, string password, ISaveLoadEvents saveLoadEvents = null, ISaveableObjectRepository repo = null) : base(objId, saveLoadEvents, repo)
        {
            this.username = username;
            this.password = password;
            playTime = new TimeSpan();
        }

        //Public Properties, Accessors and Methods
        public string Username => username;
        public string Password => password;
        public TimeSpan PlayTime => playTime;

        public PlayerDataMeta GetMeta()
        {
            return new PlayerDataMeta()
            {
                Username = username,
                Password = password,
                PlayTime = playTime
            };
        }

        public void AddPlayTime(TimeSpan time) => playTime += time;
    }
}
