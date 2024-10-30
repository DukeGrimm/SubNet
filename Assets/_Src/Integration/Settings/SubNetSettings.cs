using SubNet.Common.Interfaces.Settings;

namespace SubNet.Integration.Settings
{
    public class SubNetSettings : ISubNetSettings
    {
        //TODO: Pull these settings from someplace else
        private static string dummyFileRoot = "C:\\temp\\Personal\\SubNet";
        private static string dummySaveLocation = "\\SaveData";

        public string saveKey => "SpicyMeatballs";

        public bool useEncryption => false;

        public string FileRoot => dummyFileRoot;

        public string SavePath => FileRoot + dummySaveLocation;
    }
}
