using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _coinsScore;
    private UIManager _UIManager;
    private StorageDataGame _storageDataGame;
    private int _topCoinsScore;
    private int boost = 1;

    private void Start()
    {
        _UIManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        _storageDataGame = new StorageDataGame();
        _topCoinsScore = _storageDataGame.GetTopCoinsScore();
        _UIManager.SetTopCoinsScore(_topCoinsScore);
    }
        
    public void PickUpCoin()
    {
        _coinsScore += boost;
        _UIManager.SetTextCoins(_coinsScore);
        if (_coinsScore > _topCoinsScore)
        {
            _storageDataGame.SetTopCoinsScore(_coinsScore);
            _UIManager.SetTopCoinsScore(_coinsScore);
        }
    }

    public void SetBoost()
    {
        boost = 2;
    }

    public void ResetBoost()
    {
        boost = 1;
    }
}
