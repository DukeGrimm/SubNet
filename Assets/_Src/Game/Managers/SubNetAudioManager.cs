using EmberToolkit.Unity.Behaviours.Managers;
using SubNet.Common.Enum.Settings;

namespace SubNet.Game.Managers
{
    public class SubnetAudioManager : AudioManagerBase
    {
        //Configured to use Subnet Mixer Enum
        public override string[] GetMixerNames()
        {
            return System.Enum.GetNames(typeof(SubnetAudioMixers));
        }
    }
}
