using EmberToolkit.Common.Interfaces.Data;
using SubNet.Common.Structs.Data.Player;
using System;
using UnityEngine.SocialPlatforms;


namespace SubNet.Common.Interfaces.Player
{
    public interface IPlayerData
    {
        string Username { get; }
        string Password { get; }
        TimeSpan PlayTime { get; }
        
        PlayerDataMeta GetMeta();
    }
}
