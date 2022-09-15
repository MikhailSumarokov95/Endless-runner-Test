using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCoins;
    private int _coinsScore;
    private int _boost = 1;
   
    private void Start()
    {
        _coinsScore = PlayerPrefs.GetInt("money", 0);
        SetCoinsText(_coinsScore);
    }
        
    public void PickUpCoin()
    {
        _coinsScore += _boost;
        PlayerPrefs.SetInt("money", _coinsScore);
        SetCoinsText(_coinsScore);
    }

    public void SpentCoinInShop(int amountSpentCoins) => _coinsScore -= amountSpentCoins; 

    public void SetBoost(bool status)
    {
        if (status) _boost = 2;
        else _boost = 1;
    }

    private void SetCoinsText(int coinsScore) => _textCoins.text = "Coins: " + coinsScore.ToString();
}
