using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ToxicFamilyGames.MenuEditor
{
    public class Text : MonoBehaviour
    {
        [SerializeField]
        private string[] languages;

        private TMP_Text text;
        // Start is called before the first frame update
        void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            LanguageController lc = FindObjectOfType<LanguageController>();
            if (lc != null)
            {
                lc.InitText(this);
            }
        }

        public void SetLanguage(int selectedLanguage)
        {
            text.text = languages[selectedLanguage];
        }
    }
}