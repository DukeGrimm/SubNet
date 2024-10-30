using EmberToolkit.Unity.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Subnet.UI.Adapters.Menus.MainButtons
{

    public class ExitButtonAdapter : EmberBehaviour
    {
        [SerializeField] private Button exitBtn;

        protected override void Awake()
        {
            base.Awake();
            if (exitBtn != null || GetRequiredComponent(out exitBtn))
            {
                exitBtn.onClick.AddListener(ExitGame);
            }
        }

        private void ExitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit(); 
        #endif

        }

    }
}
