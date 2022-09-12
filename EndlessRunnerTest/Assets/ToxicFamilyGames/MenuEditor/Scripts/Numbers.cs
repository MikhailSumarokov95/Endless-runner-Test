using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace MenuEditor
    {
        [System.Serializable]
        public class Numbers : MonoBehaviour
        {

            public TMPro.TMP_Text[] texts;
            public string[] playerNumPrefs;

            // Update is called once per frame
            void FixedUpdate()
            {
                for (int i = 0; i < texts.Length; i++)
                {
                    texts[i].text = PlayerPrefs.GetInt(playerNumPrefs[i], 0) + "";
                }
            }
        }
    }
}