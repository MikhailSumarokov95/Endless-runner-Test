using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textCoins;
    [SerializeField] GameObject _tableGameOver;
    [SerializeField] Button _restartButton;
    [SerializeField] TextMeshProUGUI _textTopCoinsScore;

    public void SetTextCoins(int coins)
    {
        _textCoins.text = "Coins: " + coins;
    }

    public void SetTopCoinsScore(int topCoins)
    {
        _textTopCoinsScore.text = "TopCoins " + topCoins;
    }

    public void OnTableGameOver()
    {
        _tableGameOver.SetActive(true);
        _restartButton.onClick.AddListener(ReloadScene);
    }

    private void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}