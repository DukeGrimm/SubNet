using EmberToolkit.Unity.Behaviours;
using SubNet.Common.Interfaces.Game.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subnet.UI.Managers.Servers
{
    public class MissionListManager : EmberBehaviour
    {
        //Services
        private IMissionManager _missionManager;
        //UI Elements
        //Locals

        protected override void Awake()
        {
            base.Awake();
            RequestService(out _missionManager);
        }
    }
}
