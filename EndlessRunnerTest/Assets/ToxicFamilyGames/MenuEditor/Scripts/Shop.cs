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
            private Shoper shoper;

            [SerializeField]
            private GameObject[] items;

            [SerializeField]
            private int[] itemsPrice;

            [SerializeField]
            private float[] itemsScaleRatio;

            [Header("Кнопки")]
            [SerializeField]
            private GameObject buyButton;
            [SerializeField]
            private GameObject selectButton;

            private int selectedItem = 0;
            private Transform itemTransform;
            public static int Money
            {
                get { return PlayerPrefs.GetInt("money", 0); }
                set { PlayerPrefs.SetInt("money", value); }
            }

            public bool IsBuySelectedItem
            {
                get { return PlayerPrefs.GetInt(items[selectedItem].name, 0) == 1; }
            }

            private void Start()
            {
                itemTransform = transform.GetChild(0);
                InitItem();
                InitButtons();
                if (shoper != null)
                    shoper.OnInit(items);
                gameObject.SetActive(isActive);
            }

            [ContextMenu("NextItem")]
            public void GoNextItem()
            {
                selectedItem = (selectedItem + 1) % items.Length;
                InitItem();
            }

            [ContextMenu("PreviousItem")]
            public void GoPreviousItem()
            {
                selectedItem = (selectedItem - 1 + items.Length) % items.Length;
                InitItem();
            }

            private void InitItem()
            {
                DestroyItem();
                GameObject item = Instantiate(items[selectedItem], itemTransform);
                item.transform.localScale *= itemsScaleRatio[selectedItem];
                item.AddComponent<RotatingItem>();
                InitButtons();
            }

            private void InitButtons()
            {
                bool isBuy = IsBuySelectedItem;
                selectButton.SetActive(isBuy);
                buyButton.SetActive(!isBuy);
                (buyButton.transform.GetChild(0).GetComponent<TMP_Text>()).text = itemsPrice[selectedItem] + "";
            }

            [ContextMenu("DestroyItem")]
            private void DestroyItem()
            {
                if (itemTransform.childCount != 0) Destroy(itemTransform.GetChild(0).gameObject);
            }

            [ContextMenu("BuyItem")]
            public void BuyItem()
            {
                if (Money - itemsPrice[selectedItem] >= 0)
                {
                    Money -= itemsPrice[selectedItem];
                    PlayerPrefs.SetInt(items[selectedItem].name, 1);
                    InitButtons();
                    SelectItem();
                }
            }

            [ContextMenu("SelectItem")]
            public void SelectItem()
            {
                if (shoper != null)
                    shoper.OnSelect(selectedItem);
            }
        }
    }
}
