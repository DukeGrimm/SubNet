using EmberToolkit.Unity.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace Subnet.UI.Managers.Tools
{
    public class CodeBreakerManager : EmberBehaviour 
    {

        [SerializeField] private TMP_Text breakerText;
        [SerializeField] private int pwdSize = 6;
        [SerializeField] private string pwdChars = "madsen";
        [SerializeField] private float randomEffectSpeed = 5;
        [SerializeField] private float breakerRunSpeed = 10;
        [SerializeField] private bool isRunning = false;

        private string solvedPwd = "";
        private float lastRandomizeTime;
        private float lastSolveTime;


        private int unsolvedCount => pwdSize - solvedPwd.Count();

        protected override void Awake()
        {
            base.Awake();
            if(breakerText == null)
                GetRequiredComponent(out breakerText);
            breakerText.text = GetRandomString(pwdSize);
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (isRunning)
            {
                //Lets start with just the random effect.
                //We will implement the actual code breaking later.
                float elapsedTimeRan = Time.time - lastRandomizeTime;
                float elapsedTime = Time.time - lastSolveTime;
                if (elapsedTime > breakerRunSpeed)
                {
                    SolveNextChar();
                    lastSolveTime = Time.time;
                }
                if(solvedPwd.Count() == pwdSize)
                {
                    breakerText.text = solvedPwd;
                    isRunning = false;
                }
                else if (elapsedTimeRan > randomEffectSpeed)
                {
                    RandomizeUnsolvedParts();
                    lastRandomizeTime = Time.time;
                }

            }
        
        }

        private void SolveNextChar()
        {
            if (unsolvedCount > 0)
            {
                int solvedCount = solvedPwd.Count();
                solvedPwd += pwdChars[solvedCount];
            }
        }
        private void RandomizeUnsolvedParts()
        {
            breakerText.text = solvedPwd + GetRandomString(unsolvedCount);
        }
        /// <summary>
        /// pick a random char from a-z, 0-9
        /// </summary>
        /// <returns></returns>
        private char GetRandomAlphaNumeric()
        {
            int ranCharIndex = Random.Range(0,26+10);
            if(ranCharIndex < 26)
            {
                return (char)('a' + ranCharIndex);
            }
            else
            {
                return (char)('0' + ranCharIndex - 26);
            }

        }
        private string GetRandomString(int size)
        {
            string result = "";
            for(int i = 0; i < size; i++)
            {
                result += GetRandomAlphaNumeric();
            }
            return result;
        }
    }
}
