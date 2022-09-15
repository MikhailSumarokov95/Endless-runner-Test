using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

//PlayerPrefs money
namespace ToxicFamilyGames
{
    namespace MenuEditor
    {
        public class Shop : MonoBehaviour
        {
            [SerializeField]
            private bool isActive;

            [SerializeField]
            private SpawnManager shoper;

            [SerializeField]
            private GameObject[] items;

            [SerializeField]
            private int[] itemsPrice;

            [SerializeField]
            private float[] itemsScaleRatio;

            [SerializeField]
            private Transform PointShowItem;

            [Header("Кнопки")]
            [SerializeField]
            private GameObject buyButton;
            [SerializeField]
            private GameObject selectButton;

            private int indexShowingItem = 0;

            public static int Money
            {
                get { return PlayerPrefs.GetInt("money", 0); }
                set { PlayerPrefs.SetInt("money", value); }
            }

            public bool IsBuySelectedItem
            {
                get { return PlayerPrefs.GetInt(items[indexShowingItem].name, 0) == 1; }
            }

            private void Awake()
            {
                shoper.OnSelectCharacter(items[PlayerPrefs.GetInt("selectedItemIndex", 0)]);
            }

            private void Start()
            {
                InitItem();
                InitButtons();
                gameObject.SetActive(isActive);
            }

            [ContextMenu("NextItem")]
            public void GoNextItem()
            {
                indexShowingItem = (indexShowingItem + 1) % items.Length;
                InitItem();
            }

            [ContextMenu("PreviousItem")]
            public void GoPreviousItem()
            {
                indexShowingItem = (indexShowingItem - 1 + items.Length) % items.Length;
                InitItem();
            }

            private void InitItem()
            {
                DestroyItem();
                GameObject item = Instantiate(items[indexShowingItem], PointShowItem);
                MonoBehaviour[] components = item.GetComponents<MonoBehaviour>();
                for (int i = 0; i < components.Length; i++)
                {
                    components[i].enabled = false;
                    components[i].GetComponent<Rigidbody>().useGravity = false;
                }
                item.transform.localScale *= itemsScaleRatio[indexShowingItem];
                item.AddComponent<RotatingItem>();
                InitButtons();
            }

            private void InitButtons()
            {
                bool isBuy = IsBuySelectedItem;
                selectButton.SetActive(isBuy);
                buyButton.SetActive(!isBuy);
                (buyButton.transform.GetChild(0).GetComponent<TMP_Text>()).text = itemsPrice[indexShowingItem] + "";
            }

            [ContextMenu("DestroyItem")]
            private void DestroyItem()
            {
                if (PointShowItem.childCount != 0) Destroy(PointShowItem.GetChild(0).gameObject);
            }

            [ContextMenu("BuyItem")]
            public void BuyItem()
            {
                if (Money - itemsPrice[indexShowingItem] >= 0)
                {
                    Money -= itemsPrice[indexShowingItem];
                    PlayerPrefs.SetInt(items[indexShowingItem].name, 1);
                    InitButtons();
                    SelectItem();
                }
            }

            [ContextMenu("SelectItem")]
            public void SelectItem()
            {
                PlayerPrefs.SetInt("selectedItemIndex", indexShowingItem);
                if (shoper != null)
                    shoper.OnSelectCharacter(items[indexShowingItem]);
            }
        }
    }
}
