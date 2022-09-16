using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCoins;
    private int _boost = 1;

    public void PickUpCoin()
    {
        var coinsScore = PlayerPrefs.GetInt("money", 0) + 1 * _boost;
        PlayerPrefs.SetInt("money", coinsScore);
    }

    public void SpentCoinInShop(int amountSpentCoins)
    {
        var coinsScore = PlayerPrefs.GetInt("money", 0) - amountSpentCoins;
        PlayerPrefs.SetInt("money", coinsScore);
    }

    public void SetBoost(bool status)
    {
        if (status) _boost = 2;
        else _boost = 1;
    }

    public void RewardCoins(int coinsRewarded)
    {
        var coinsScore = PlayerPrefs.GetInt("money", 0) + coinsRewarded;
        PlayerPrefs.SetInt("money", coinsScore);
    }
}
