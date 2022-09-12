using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace MenuEditor
    {
        public abstract class Shoper : MonoBehaviour
        {
            public abstract void OnInit(GameObject[] items);
            public abstract void OnSelect(int selectedItem);
        }
    }
}