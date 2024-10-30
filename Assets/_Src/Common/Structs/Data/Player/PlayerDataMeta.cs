using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Structs.Data.Player
{
    public struct PlayerDataMeta
    {
        public string Username;
        public string Password;
        public TimeSpan PlayTime;

        public bool IsValid => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
    }
}
